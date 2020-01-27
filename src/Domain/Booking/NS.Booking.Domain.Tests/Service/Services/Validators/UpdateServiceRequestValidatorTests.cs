namespace NS.Booking.Domain.Tests.Service.Services.Validators
{
    using System.Collections.Generic;

    using Moq;

    using Newshore.Core.IoC;
    using Newshore.Core.IoC.Interfaces;

    using NS.Booking.Common.Domain.Common.Validators;
    using NS.Booking.Common.Domain.Service.Enums;
    using NS.Booking.Domain.Service.Exceptions;
    using NS.Booking.Domain.Service.Models.Requests;
    using NS.Booking.Domain.Service.Services.Validators;

    using NUnit.Framework;

    [TestFixture]
    public class UpdateServiceRequestValidatorTests
    {

        private IValidator<UpdateServiceRequest> validator;
        private UpdateServiceRequest validServiceRequest;
        private Mock<IIoCContainer> iocContainerMock;

        [SetUp]
        public void Setup()
        {
            this.iocContainerMock = new Mock<IIoCContainer>(MockBehavior.Strict);
            IoCContainer.Instance = this.iocContainerMock.Object;
            this.validator = new UpdateServiceRequestValidator();
            iocContainerMock.Setup(x => x.ResolveAll<IValidator<UpdateServiceRequest>>()).Returns(new List<IValidator<UpdateServiceRequest>>() { this.validator });
            this.validServiceRequest = new UpdateServiceRequest
            {
                ServiceId = "ASDFASDFASD4FA65D4SF6A4DS",
                Code = "MEAL2",
                ServiceSellKey = "1231",
                SellKey = "1",
                PaxId = "1",
                Type = ServiceType.Baggage
            };
        }

        [TearDown]
        public void TearDown()
        {
            iocContainerMock.VerifyAll();
        }

        [TestCase(null, null, null)]
        [TestCase("", "CHD", "1561")]
        [TestCase("", "", "1235")]
        [TestCase("", "", "")]
        public void TestInvalidUpdateServieRequest(string servidId, string code, string serviceSellKey)
        {
            this.validServiceRequest.Code = code;
            this.validServiceRequest.ServiceSellKey = serviceSellKey;
            this.validServiceRequest.ServiceId = servidId;

            Assert.Throws<InvalidUpdateServiceRequestInformationException>(() => this.validator.Validate(this.validServiceRequest));
        }

        [Test]
        public void DoesNotThrowWhenUpdateServiceRequestIsValid()
        {
            Assert.DoesNotThrow(() => this.validator.Validate(this.validServiceRequest));
        }
    }
}
