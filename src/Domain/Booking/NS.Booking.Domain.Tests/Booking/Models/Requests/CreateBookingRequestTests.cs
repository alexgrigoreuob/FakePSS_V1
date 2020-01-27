namespace NS.Booking.Domain.Tests.Booking.Models.Requests
{
    using System.Collections.Generic;

    using NS.Booking.Domain.Booking.Exceptions;
    using NS.Booking.Domain.Booking.Models;
    using NS.Booking.Domain.Booking.Models.Requests;
    using NS.Booking.Domain.Pax.Models;

    using NUnit.Framework;

    [TestFixture]
    public class CreateBookingRequestTests
    {
        [Test]
        public void ValidateDoesNotThrowWhenValid()
        {
            var request = new CreateBookingRequest
                              {
                                  Booking = new Booking
                                                {
                                                    Pax = new List<Pax>
                                                              {
                                                                  new Pax()
                                                              }
                                                }
                              };
            Assert.DoesNotThrow(() => request.Validate());
        }

        [Test]
        public void ValidateThrowsWhenInvalid()
        {
            var request = new CreateBookingRequest
                              {
                                  Booking = new Booking
                                                {
                                                    Pax = new List<Pax>()
                                                }
                              };
            Assert.Throws<InvalidBookingInformationException>(() => request.Validate());
        }
    }
}