using Newshore.Core.NativeObjects.Extensions;
using NS.Booking.Common.Domain.Common.Validators;
using NS.Booking.Domain.Account.Exceptions;
using NS.Booking.Domain.Account.Models;
using NS.Booking.Domain.Account.Services.Validators;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NS.Booking.Domain.Tests.Account.Services.Validators
{
    [TestFixture]
    public class AgentValidatorTests
    {
        private IValidator<Agent> _validator;
        private Agent _validAgent;
        private Agent _invalidAgent;

        [SetUp]
        public void Setup()
        {
            _validator = new AgentValidator();
            _validAgent = new Agent
            {
                Username = "Test",
                Credit = new CreditAccount { CreditAvailable = 0, CurrencyCode = "UDS" },
                Organization = new Organization { ReferenceId = "referenceId", Name = "test" },
                Status = Domain.Account.Enums.AccountStatus.Active,
                ReferenceId = "referenceId",
                Type = Domain.Account.Enums.AccountType.Agent
            };
            _invalidAgent = new Agent
            {
                Username = string.Empty,
                Status = Domain.Account.Enums.AccountStatus.Locked,
                ReferenceId = "refereceId",
                Organization = new Organization()
            };
        }

        [Test]
        public void ThrowsWhenTypeIsNotAgent()
        {
            Assert.Throws<InvalidAgentInformationException>(() => _validator.Validate(new Agent { ReferenceId = "referenceId", Credit = new CreditAccount(), Status = Domain.Account.Enums.AccountStatus.Active, Username = "test", Type = Domain.Account.Enums.AccountType.Default, Organization = new Organization { Name = "name", ReferenceId = string.Empty } }));
        }

        [Test]
        public void ThrowsWhenOrganizationIsNull()
        {
            Assert.Throws<InvalidAgentInformationException>(() => _validator.Validate(new Agent { ReferenceId = "referenceId", Credit = new CreditAccount(), Status = Domain.Account.Enums.AccountStatus.Active, Username = "test", Type = Domain.Account.Enums.AccountType.Agent }));
        }

        [Test]
        public void ThrowsWhenOrganizationCodeIsEmpty()
        {
            Assert.Throws<InvalidAgentInformationException>(() => _validator.Validate(new Agent { ReferenceId = "referenceId", Credit = new CreditAccount(), Status = Domain.Account.Enums.AccountStatus.Active, Username = "test", Type = Domain.Account.Enums.AccountType.Agent, Organization = new Organization { Name = "name", ReferenceId = string.Empty } }));
        }

        [Test]
        public void ThrowsWhenUserNameIsEmpty()
        {
            Assert.Throws<InvalidAgentInformationException>(() => _validator.Validate(new Agent { ReferenceId = "referenceId", Credit = new CreditAccount(), Status = Domain.Account.Enums.AccountStatus.Active, Username = string.Empty, Type = Domain.Account.Enums.AccountType.Agent, Organization = new Organization { Name = "name", ReferenceId = "referenceId" } }));
        }

        [Test]
        public void DoesNotThrowWhenAgentIsValid()
        {
            Assert.DoesNotThrow(() => { _validAgent.Validate(); });
        }

        [Test]
        public void DoesNotThrowWhenAgentIsValidValidate()
        {
            Assert.DoesNotThrow(() => { this._validator.Validate(_validAgent); });
        }

        [Test]
        public void BuildingValidOrganizationId()
        {
            var Name = "test";
            var refId = "referenceId".EncodeHexadecimal();
            var value = $"{Name}~{refId}";
            var Id = value.EncodeHexadecimal();

            Assert.AreEqual(Id, _validAgent.Organization.Id);
        }

        [Test]
        public void BuildingInvalidOrganizationId()
        {
            var Name = "test";
            var refId = "referenceId".EncodeHexadecimal();
            var value = $"{Name}~{refId}";
            var Id = value.EncodeHexadecimal();

            Assert.AreNotEqual(Id, _invalidAgent.Organization.Id);
        }

    }
}
