namespace NS.Booking.Domain.Tests.Bundle.Models.Request
{
    using System.Collections.Generic;
    using Moq;
    using NUnit.Framework;
    using Newshore.Core.IoC;
    using Newshore.Core.IoC.Interfaces;
    using NS.Booking.Common.Domain.Common.Validators;
    using NS.Booking.Domain.Bundles.Models.Requests;  

    [TestFixture]
    public class AddBundleRequestTest
    {
        [Test]
        public void ValidatePerformsValidatorsIteration()
        {
            var iocInstance = IoCContainer.Instance;
            var iocInstanceMock = new Mock<IIoCContainer>(MockBehavior.Strict);
            IoCContainer.Instance = iocInstanceMock.Object;
            var firstValidatorMock = new Mock<IValidator<AddBundleRequest>>(MockBehavior.Strict);
            var secondValidatorMock = new Mock<IValidator<AddBundleRequest>>(MockBehavior.Strict);
            iocInstanceMock.Setup(x => x.ResolveAll<IValidator<AddBundleRequest>>()).Returns(
                new List<IValidator<AddBundleRequest>> { firstValidatorMock.Object, secondValidatorMock.Object });
            var sut = new AddBundleRequest();
            firstValidatorMock.Setup(x => x.Validate(sut));
            secondValidatorMock.Setup(x => x.Validate(sut));

            sut.Validate();

            iocInstanceMock.VerifyAll();
            firstValidatorMock.VerifyAll();
            secondValidatorMock.VerifyAll();
            IoCContainer.Instance = iocInstance;
        }
    }
}
