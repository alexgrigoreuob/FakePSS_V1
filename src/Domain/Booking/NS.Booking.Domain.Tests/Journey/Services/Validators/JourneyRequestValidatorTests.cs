namespace NS.Booking.Domain.Tests.Journey.Services.Validators
{
    using NS.Booking.Common.Domain.Common.Validators;
    using NS.Booking.Domain.Journey.Exceptions;
    using NS.Booking.Domain.Journey.Models.Requests;
    using NS.Booking.Domain.Journey.Services.Validators;
    using NUnit.Framework;

    [TestFixture]
    public class JourneyRequestValidatorTests
    {
        private IValidator<JourneyRequest> _validator;

        [SetUp]
        public void Setup()
        {
            _validator = new JourneyRequestValidator();
        }

        [Test]
        public void ThrowsWhenNullRequest()
        {
            Assert.Throws<InvalidJourneyInformationException>(() =>
            {
                _validator.Validate(null);
            });
        }

        [TestCase(null, null)]
        [TestCase("123abcxx", "")]
        [TestCase("123abc456def", null)]
        [TestCase("", "123abcxxx")]
        public void ThrowsWhenInvalidDataRequest(string journeyId, string fareId)
        {
            var request = new JourneyRequest
            {
                FareId = fareId,
                JourneyId = journeyId
            };
            Assert.Throws<InvalidJourneyInformationException>(() =>
            {
                this._validator.Validate(request);
            });
        }

        [Test]
        public void DoesNotThrowWhenRequestIsValid()
        {
            var request = new JourneyRequest
            {
                FareId = "123abc",
                JourneyId = "DEF456"
            };
            Assert.DoesNotThrow(() => _validator.Validate(request));
        }
    }
}
