namespace NS.Booking.Domain.Tests.Journey.Services.Validators
{
    using NS.Booking.Common.Domain.Common.Validators;
    using NS.Booking.Domain.Journey.Exceptions;
    using NS.Booking.Domain.Journey.Models;
    using NS.Booking.Domain.Journey.Services.Validators;
    using NUnit.Framework;
    using System.Collections.Generic;
    using System.Linq;

    [TestFixture]
    public class JourneyValidatorTests
    {
        private IValidator<Journey> _validator;
        private Journey _validJourney;

        [SetUp]
        public void Setup()
        {
            _validator = new JourneyValidator();
            _validJourney = new MockValidJourney().Journey;
        }

        [Test]
        public void ThrowsWhenNullJourney()
        {
            Assert.Throws<InvalidJourneyInformationException>(() =>
            {
                _validator.Validate(null);
            });
        }

        [TestCase(null, null)]
        [TestCase("", "")]
        [TestCase("BCN", null)]
        [TestCase("", "MZL")]
        public void ThrowsWhenInvalidSegmentsLegsData(string origin, string destination)
        {
            this._validJourney.Segments.First().Legs.First().Origin = origin;
            this._validJourney.Segments.First().Legs.First().Destination = destination;

            Assert.Throws<InvalidJourneyInformationException>(() =>
            {
                this._validator.Validate(this._validJourney);
            });
        }

        [Test]
        public void ThrowsWhenNoSegments()
        {
            this._validJourney.Segments = new List<Segment>();
            Assert.Throws<InvalidJourneyInformationException>(() =>
            {
                _validator.Validate(this._validJourney);
            });
        }

        [Test]
        public void DoesNotThrowWhenJouneyIsValid()
        {
            Assert.DoesNotThrow(() => _validator.Validate(_validJourney));
        }
    }
}
