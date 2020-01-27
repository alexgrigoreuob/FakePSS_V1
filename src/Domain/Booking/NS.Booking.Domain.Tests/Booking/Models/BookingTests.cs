namespace NS.Booking.Domain.Tests.Booking.Models
{
    using System;
    using System.Collections.Generic;

    using Newshore.Core.NativeObjects.Extensions;

    using NS.Booking.Domain.Booking.Exceptions;
    using NS.Booking.Domain.Booking.Models;
    using NS.Booking.Domain.Journey.Models;
    using NS.Booking.Domain.Pax.Models;

    using NUnit.Framework;

    [TestFixture]
    public class BookingTests
    {
        [Test]
        public void IdIsEmptyWhenBookingHasNoRecordLocator()
        {
            Assert.AreEqual(string.Empty, new Booking().Id);
        }

        [Test]
        public void IdIsCorrectlyGeneratedWhenHasRecordLocator()
        {
            var booking = new Booking { BookingInfo = { RecordLocator = "RecordLocator", CreatedDate = DateTime.Today, ReferenceId = "1" } };
            var expectedId = $"{booking.BookingInfo.RecordLocator}~{booking.BookingInfo.CreatedDate:yyyy-MM-dd}~{booking.BookingInfo.ReferenceId.EncodeHexadecimal()}";
            Assert.AreEqual(expectedId.EncodeHexadecimal(), booking.Id);
        }

        [Test]
        public void ValidateThrowsWhenBookingIsNotValid()
        {
            Assert.Throws<InvalidBookingInformationException>(() => new Booking().Validate());
        }

        [Test]
        public void ValidateDoesNotThrowWhenBookingIsValid()
        {
            var booking = new Booking
                              {
                                  Pax = new List<Pax> { new Pax() },
                                  Journeys = new List<Journey> { new Journey() }
                              };
            Assert.DoesNotThrow(() => booking.Validate());
        }    
    }
}