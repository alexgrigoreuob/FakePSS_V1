namespace NS.Booking.Domain.Tests.Service.Models.Requests
{
    using System.Collections.Generic;

    using Moq;

    using Newshore.Core.IoC;
    using Newshore.Core.IoC.Interfaces;

    using NS.Booking.Common.Domain.Common.Validators;
    using NS.Booking.Domain.Service.Models.Requests;

    using NUnit.Framework;

    [TestFixture]
    public class AddServiceRequestTests
    {
        [Test]
        public void ValidatePerformsValidatorsIteration()
        {
            var iocInstance = IoCContainer.Instance;
            var iocInstanceMock = new Mock<IIoCContainer>(MockBehavior.Strict);
            IoCContainer.Instance = iocInstanceMock.Object;
            var firstValidatorMock = new Mock<IValidator<AddServiceRequest>>(MockBehavior.Strict);
            var secondValidatorMock = new Mock<IValidator<AddServiceRequest>>(MockBehavior.Strict);
            iocInstanceMock.Setup(x => x.ResolveAll<IValidator<AddServiceRequest>>()).Returns(
                new List<IValidator<AddServiceRequest>> { firstValidatorMock.Object, secondValidatorMock.Object });
            var sut = new AddServiceRequest();
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