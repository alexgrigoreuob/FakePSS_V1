namespace NS.Booking.Domain.Tests.Service.Services.Validators
{
    using System.Collections.Generic;
    using System.Linq;
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
    public class AutoAssignSeatRequestValidatorTests
    {
        private IValidator<AutoAssignSeatRequest> validator;
        private AutoAssignSeatRequest validServiceRequest;
        private Mock<IIoCContainer> iocContainerMock;

        [SetUp]
        public void Setup()
        {
            this.iocContainerMock = new Mock<IIoCContainer>(MockBehavior.Strict);
            IoCContainer.Instance = this.iocContainerMock.Object;
            this.validator = new AutoAssignSeatRequestValidator();
            iocContainerMock.Setup(x => x.ResolveAll<IValidator<AutoAssignSeatRequest>>()).Returns(new List<IValidator<AutoAssignSeatRequest>>() { this.validator });

            this.validServiceRequest = new AutoAssignSeatRequest
            {
                SegmentId = "1",
                Pax = new List<string>() {"1"}
            };


        }

        [TearDown]
        public void TearDown()
        {
            iocContainerMock.VerifyAll();
        }

        [Test]
        public void ThrowsWhenNoAvailableRequest()
        {
            Assert.Throws<InvalidAutoAssignSeatRequestInformationException>(() => { this.validator.Validate(null); });
        }

        [TestCase(null, null)]
        [TestCase("", "")]
        [TestCase("SWA1", "")]
        public void ThrowsWhenInvalidPaymentData(string code, string serviceSellKey)
        {
            this.validServiceRequest.Pax = new List<string>() {code};
            
            this.validServiceRequest.SegmentId = serviceSellKey;

            Assert.Throws<InvalidAutoAssignSeatRequestInformationException>(() => this.validator.Validate(this.validServiceRequest));
            
        }

        [Test]
        public void DoesNotThrowWhenAssignIsValid()
        {
            Assert.DoesNotThrow(() => this.validator.Validate(this.validServiceRequest));
        }
    }
}
