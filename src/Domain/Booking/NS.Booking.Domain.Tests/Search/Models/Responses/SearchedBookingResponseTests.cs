using NS.Booking.Domain.Search.Exceptions;
using NS.Booking.Domain.Search.Models.Responses;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NS.Booking.Domain.Tests.Search.Models.Responses
{
    public class SearchedBookingResponseTests
    {
        private SearchedBookingResponse _searchValidBookingResponse;
        private SearchedBookingResponse _searchInvalidBookingResponse;

        [SetUp]
        public void SetUp()
        {
            _searchValidBookingResponse = new SearchedBookingResponse
            {
                Bookings = new List<Domain.Booking.Models.Booking>(),
                TotalRecords = 40
            };
            _searchInvalidBookingResponse = new SearchedBookingResponse();
        }

        [Test]
        public void ShouldReturnInvalidSearchBookings()
        {
            Assert.IsNull(_searchInvalidBookingResponse.Bookings);
        }

        [Test]
        public void ShouldReturnValidSearchBookings()
        {
            Assert.IsNotNull(_searchValidBookingResponse.Bookings );
        }
    }
}
