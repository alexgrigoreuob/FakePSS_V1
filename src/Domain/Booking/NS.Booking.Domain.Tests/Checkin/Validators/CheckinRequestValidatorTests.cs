namespace NS.Booking.Domain.Tests.Checkin.Validators
{
    using NS.Booking.Common.Domain.Common.Validators;
    using NS.Booking.Domain.Checkin.Exceptions;
    using NS.Booking.Domain.Checkin.Models.Requests;
    using NS.Booking.Domain.Checkin.Validators;
    using NUnit.Framework;
    using System.Collections.Generic;

    [TestFixture]
    public class CheckinRequestValidatorTests
    {
        private IValidator<CheckinRequest> _validator;

        [SetUp]
        public void Setup()
        {
            this._validator = new CheckinRequestValidator();
        }

        [Test]
        public void ThrowsWhenNullRequest()
        {
            Assert.Throws<InvalidCheckinRequestInformationException>(() =>
            {
                this._validator.Validate(null);
            });
        }

        [Test]
        public void ThrowsWhenEmptyRequest()
        {
            Assert.Throws<InvalidCheckinRequestInformationException>(() =>
            {
                this._validator.Validate(new CheckinRequest());
            });
        }

        [Test]
        public void DoesNotThrowWhenRequestIsValid()
        {
            Assert.DoesNotThrow(() =>
            {
                this._validator.Validate(new CheckinRequest
                {
                    Pax = new List<string> { "TEST123", "TEST456" },
                    SegmentId = "123ABC"
                });
            });
        }
    }
}
