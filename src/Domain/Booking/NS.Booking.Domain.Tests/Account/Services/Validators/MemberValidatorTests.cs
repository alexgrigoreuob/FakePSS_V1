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
    public class MemberValidatorTests
    {

        private IValidator<Member> _validator;
        private Member _validMember;


        [SetUp]
        public void Setup()
        {
            _validator = new MemberValidator();
            _validMember = new Member
            {
                Username = "Test",
                Status = Domain.Account.Enums.AccountStatus.Active,
                ReferenceId = "referenceId",
                Type = Domain.Account.Enums.AccountType.Member
            };
        }

        [Test]
        public void ThrowsWhenTypeIsNotAgent()
        {
            Assert.Throws<InvalidMemberInformationException>(() => _validator.Validate(new Member { ReferenceId = "referenceId", Credit = new CreditAccount(), Status = Domain.Account.Enums.AccountStatus.Active, Username = "test", Type = Domain.Account.Enums.AccountType.Default }));
        }

        [Test]
        public void ThrowsWhenUserNameIsEmpty()
        {
            Assert.Throws<InvalidMemberInformationException>(() => _validator.Validate(new Member { ReferenceId = "referenceId", Status = Domain.Account.Enums.AccountStatus.Active, Username = string.Empty, Type = Domain.Account.Enums.AccountType.Member }));
        }

        [Test]
        public void DoesNotThrowWhenMemberIsValid()
        {
            Assert.DoesNotThrow(() => _validMember.Validate());
        }

        [Test]
        public void DoesNotThrowWhenMemberIsValidValidate()
        {
            Assert.DoesNotThrow(() => { this._validator.Validate(_validMember); });
        }
    }
}
