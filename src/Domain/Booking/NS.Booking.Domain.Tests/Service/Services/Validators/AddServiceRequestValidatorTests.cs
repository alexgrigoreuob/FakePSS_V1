namespace NS.Booking.Domain.Tests.Service.Services.Validators
{
    using System.Collections.Generic;

    using Moq;

    using Newshore.Core.IoC;
    using Newshore.Core.IoC.Interfaces;

    using NS.Booking.Common.Domain.Charge.Models;
    using NS.Booking.Common.Domain.Common.Validators;
    using NS.Booking.Domain.Service.Exceptions;
    using NS.Booking.Domain.Service.Models.Requests;
    using NS.Booking.Domain.Service.Services.Validators;

    using NUnit.Framework;

    [TestFixture]
    public class AddServiceRequestValidatorTests
    {
        private IValidator<AddServiceRequest> validator;
        private AddServiceRequest validServiceRequest;
        private Mock<IIoCContainer> iocContainerMock;

        [SetUp]
        public void Setup()
        {
            this.iocContainerMock = new Mock<IIoCContainer>(MockBehavior.Strict);
            IoCContainer.Instance = this.iocContainerMock.Object;
            this.validator = new AddServiceRequestValidator();
            iocContainerMock.Setup(x => x.ResolveAll<IValidator<AddServiceRequest>>()).Returns(new List<IValidator<AddServiceRequest>>() { this.validator });
            
            this.validServiceRequest = new AddServiceRequest
            {
                Code = "MEAL2",
                ServiceSellKey = "1231",
                SellKey = "1",
                PaxId = "1",
                Type = Common.Domain.Service.Enums.ServiceType.Meal,
                Charges = new List<Charge>()
            };
        }

        [TearDown]
        public void TearDown()
        {
            iocContainerMock.VerifyAll();
        }

        [Test]
        public void ThrowsWhenNullPayment()
        {
            Assert.Throws<InvalidAddServiceRequestInformationException>(() => { this.validator.Validate(null); });
        }

        [TestCase(null, null)]
        [TestCase("", "1235")]
        [TestCase("", "")]
        [TestCase("SWA1", "")]
        public void ThrowsWhenInvalidPaymentData(string code, string serviceSellKey)
        {
            this.validServiceRequest.Code = code;
            this.validServiceRequest.ServiceSellKey = serviceSellKey;

            Assert.Throws<InvalidAddServiceRequestInformationException>(() => this.validator.Validate(this.validServiceRequest));
        }

        [Test]
        public void DoesNotThrowWhenPaymentIsValid()
        {
            Assert.DoesNotThrow(() => this.validator.Validate(this.validServiceRequest));
        }
    }
}
