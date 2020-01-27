namespace NS.Booking.Domain.Tests.Search.Models.Requests
{
    using NS.Booking.Domain.Search.Enums;
    using NS.Booking.Domain.Search.Exceptions;
    using NS.Booking.Domain.Search.Models.Requests;
    using NUnit.Framework;
    using System.Collections.Generic;

    [TestFixture]
    public class SearchBookingRequestTests
    {
        private SearchBookingRequest _searchValidBookingRequest;
        private SearchBookingRequest _searchInvalidBookingRequest;

        [SetUp]
        public void SetUp()
        {
            _searchValidBookingRequest = new SearchBookingRequest
            {
                Filters = new List<KeyValuePair<SearchBookingFilterType, string>>(),
                ItemsPerPage = 50,
                Page = 2
            };

            _searchInvalidBookingRequest = new SearchBookingRequest();
        }

        [Test]
        public void ShouldReturnInvalidSearchBookings()
        {
            Assert.Throws<InvalidSearchInformationException>(() => _searchInvalidBookingRequest.Validate());
        }

        [Test]
        public void ShouldReturnValidSearchBookings()
        {
            Assert.DoesNotThrow(() => _searchValidBookingRequest.Validate());
        }
    }
}

