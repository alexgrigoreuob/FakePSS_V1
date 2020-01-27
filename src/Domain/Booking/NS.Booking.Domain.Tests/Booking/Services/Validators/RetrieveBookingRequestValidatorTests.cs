namespace NS.Booking.Domain.Tests.Booking.Services.Validators
{
    using NS.Booking.Common.Domain.Common.Validators;
    using NS.Booking.Domain.Booking.Exceptions;
    using NS.Booking.Domain.Booking.Models.Requests;
    using NS.Booking.Domain.Booking.Services.Validators;
    using NUnit.Framework;

    [TestFixture]
    public class RetrieveBookingRequestValidatorTests
    {
        private IValidator<RetrieveBookingRequest> _validator;

        [SetUp]
        public void Setup()
        {
            this._validator = new RetrieveBookingRequestValidator();
        }

        [Test]
        public void ThrowsWhenNullRequest()
        {
            Assert.Throws<InvalidBookingInformationException>(() =>
            {
                this._validator.Validate(null);
            });
        }

        [Test]
        public void ThrowsWhenNullRecordLocator()
        {
            Assert.Throws<InvalidBookingInformationException>(() =>
            {
                this._validator.Validate(new RetrieveBookingRequest());
            });
        }

        [Test]
        public void ThrowsWhenNoInfoInRequest()
        {
            Assert.Throws<InvalidBookingInformationException>(() =>
            {
                this._validator.Validate(new RetrieveBookingRequest
                {
                    RecordLocator = "123ABC"
                });
            });
        }

        [Test]
        public void DoesNotThrowWhenRequestIsValid()
        {
            Assert.DoesNotThrow(() =>
            {
                this._validator.Validate(new RetrieveBookingRequest
                {
                    RecordLocator = "123ABC",
                    PaxSurname = "Test"
                });
            });
        }
    }
}
