namespace NS.Booking.Domain.Tests.Journey.Services.Validators
{
    using NS.Booking.Common.Domain.Common.Validators;
    using NS.Booking.Domain.Checkin.Exceptions;
    using NS.Booking.Domain.Checkin.Models.Requests;
    using NS.Booking.Domain.Checkin.Validators;
    using NUnit.Framework;
    using System.Collections.Generic;

    [TestFixture]
    public class SegmentCheckinRequestValidatorTests
    {
        private IValidator<CheckinRequest> _validator;
        private CheckinRequest _validSegmentCheckinRequest;

        [SetUp]
        public void Setup()
        {
            _validator = new CheckinRequestValidator();
            _validSegmentCheckinRequest = new CheckinRequest
            {
                SegmentId = "1234abcd",
                Pax = new List<string> { "abc345", "2356test" }
            };
        }

        [Test]
        public void ThrowsWhenNullRequest()
        {
            Assert.Throws<InvalidCheckinRequestInformationException>(() =>
            {
                _validator.Validate(null);
            });
        }

        [Test]
        public void ThrowsWhenInvalidSegmentRequest()
        {
            this._validSegmentCheckinRequest.SegmentId = null;
            Assert.Throws<InvalidCheckinRequestInformationException>(() =>
            {
                _validator.Validate(this._validSegmentCheckinRequest);
            });
        }

        [Test]
        public void ThrowsWhenInvalidPaxRequest()
        {
            this._validSegmentCheckinRequest.Pax[0] = null;
            Assert.Throws<InvalidCheckinRequestInformationException>(() =>
            {
                _validator.Validate(this._validSegmentCheckinRequest);
            });
        }

        [Test]
        public void DoesNotThrowWhenRequestIsValid()
        {
            Assert.DoesNotThrow(() => _validator.Validate(_validSegmentCheckinRequest));
        }
    }
}
