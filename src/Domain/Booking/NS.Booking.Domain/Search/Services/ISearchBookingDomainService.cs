namespace NS.Booking.Domain.Search.Services
{
    using NS.Booking.Domain.Booking.Models;
    using NS.Booking.Domain.Search.Models.Requests;
    using NS.Booking.Domain.Search.Models.Responses;
    using System.Collections.Generic;

    public interface ISearchBookingDomainService
    {
        SearchedBookingResponse Search(SearchBookingRequest searchBookingRequest);
    }
}
