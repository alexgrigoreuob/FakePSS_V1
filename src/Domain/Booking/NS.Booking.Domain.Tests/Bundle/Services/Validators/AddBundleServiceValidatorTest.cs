namespace NS.Booking.Domain.Tests.Bundle.Services.Validators
{
    using System.Collections.Generic;
    using Moq;
    using NUnit.Framework;
    using Newshore.Core.IoC;
    using Newshore.Core.IoC.Interfaces;
    using NS.Booking.Common.Domain.Common.Validators;
    using NS.Booking.Domain.Bundles.Exceptions;
    using NS.Booking.Domain.Bundles.Models.Requests;
    using NS.Booking.Domain.Bundles.Services.Validators;
    
    [TestFixture]
    public class AddBundleServiceValidatorTest
    {
        private readonly IIoCContainer instance = IoCContainer.Instance;

        private IValidator<AddBundleRequest> validator;
        private AddBundleRequest validBundleRequest;
        private Mock<IIoCContainer> iocContainerMock;
        
        [SetUp]
        public void Setup()
        {
            this.iocContainerMock = new Mock<IIoCContainer>(MockBehavior.Strict);
            IoCContainer.Instance = this.iocContainerMock.Object;
            this.validator = new AddBundleRequestValidator();
            iocContainerMock.Setup(x => x.ResolveAll<IValidator<AddBundleRequest>>()).Returns(new List<IValidator<AddBundleRequest>>() { this.validator });

            this.validBundleRequest = new AddBundleRequest
            {
                Code = "STPLUS",
                BundleSellKey = "1231",
                SellKey = "1",
                PaxId = "1"
            };
        }

        [TearDown]
        public void TearDown()
        {
            iocContainerMock.VerifyAll();
            IoCContainer.Instance = this.instance;
        }

        [Test]
        public void ThrowsWhenNullBundle()
        {
            Assert.Throws<InvalidAddBundleRequestInformationException>(() => { this.validator.Validate(null); });
        }

        [TestCase(null, null, null, null)]
        [TestCase("", "1235", "1", "1")]
        [TestCase("", "", "", "")]
        public void ThrowsWhenInvalidBundleData(string code, string serviceSellKey, string sellKey, string paxId)
        {
            this.validBundleRequest.Code = code;
            this.validBundleRequest.BundleSellKey = serviceSellKey;
            this.validBundleRequest.SellKey = sellKey;
            this.validBundleRequest.PaxId = paxId;

            Assert.Throws<InvalidAddBundleRequestInformationException>(() => this.validator.Validate(this.validBundleRequest));
        }

        [Test]
        public void DoesNotThrowWhenBundleIsValid()
        {
            Assert.DoesNotThrow(() => this.validator.Validate(this.validBundleRequest));
        }
    }
}
