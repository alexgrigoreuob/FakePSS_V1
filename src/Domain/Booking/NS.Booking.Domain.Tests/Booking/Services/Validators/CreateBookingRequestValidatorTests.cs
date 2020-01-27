namespace NS.Booking.Domain.Tests.Booking.Services.Validators
{
    using NS.Booking.Common.Domain.Common.Validators;
    using NS.Booking.Domain.Booking.Exceptions;
    using NS.Booking.Domain.Booking.Models;
    using NS.Booking.Domain.Booking.Models.Requests;
    using NS.Booking.Domain.Booking.Services.Validators;
    using NS.Booking.Domain.Pax.Models;
    using NUnit.Framework;
    using System.Collections.Generic;

    [TestFixture]
    public class CreateBookingRequestValidatorTests
    {
        private IValidator<CreateBookingRequest> _validator;

        [SetUp]
        public void Setup()
        {
            this._validator = new CreateBookingRequestValidator();
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
        public void ThrowsWhenNullBooking()
        {
            Assert.Throws<InvalidBookingInformationException>(() =>
            {
                this._validator.Validate(new CreateBookingRequest());
            });
        }

        [Test]
        public void ThrowsWhenNoPaxInBooking()
        {
            Assert.Throws<InvalidBookingInformationException>(() =>
            {
                this._validator.Validate(new CreateBookingRequest
                {
                    Booking = new Booking()
                });
            });
        }

        [Test]
        public void DoesNotThrowWhenPaxInBooking()
        {
            Assert.DoesNotThrow(() =>
            {
                this._validator.Validate(new CreateBookingRequest
                {
                    Booking = new Booking
                    {
                        Pax = new List<Pax>
                        {
                            new Pax()
                        }
                    }
                });
            });
        }
    }
}
