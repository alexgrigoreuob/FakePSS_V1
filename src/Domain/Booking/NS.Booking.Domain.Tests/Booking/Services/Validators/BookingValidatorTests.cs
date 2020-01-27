namespace NS.Booking.Domain.Tests.Booking.Services.Validators
{
    using NS.Booking.Common.Domain.Common.Validators;
    using NS.Booking.Domain.Booking.Exceptions;
    using NS.Booking.Domain.Booking.Models;
    using NS.Booking.Domain.Booking.Services.Validators;
    using NS.Booking.Domain.Journey.Models;
    using NS.Booking.Domain.Pax.Models;
    using NUnit.Framework;
    using System.Collections.Generic;

    [TestFixture]
    public class BookingValidatorTests
    {
        private IValidator<Booking> validator;

        private Booking validBooking;

        [SetUp]
        public void Setup()
        {
            this.validator = new BookingValidator();
            this.validBooking = new Booking { Pax = new List<Pax> { new Pax() }, Journeys = new List<Journey> { new Journey() } };
        }

        [Test]
        public void ThrowsWhenBookingIsNull()
        {
            Assert.Throws<InvalidBookingInformationException>(() => { this.validator.Validate(null); });
        }

        [Test]
        public void ThrowsWhenNoPax()
        {
            validBooking.Pax = new List<Pax>();
            Assert.Throws<InvalidBookingInformationException>(() => { this.validator.Validate(validBooking); });
        }

        [Test]
        public void ThrowsWhenNoJourney()
        {
            validBooking.Journeys = new List<Journey>();
            Assert.Throws<InvalidBookingInformationException>(() => { this.validator.Validate(null); });
        }

        [Test]
        public void DoesNotThrowWhenBookingIsValid()
        {
            Assert.DoesNotThrow(() => { this.validator.Validate(validBooking); });
        }
    }
}