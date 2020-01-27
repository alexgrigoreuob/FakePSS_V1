namespace NS.Booking.Domain.Search.Models.Responses
{
    using NS.Booking.Domain.Booking.Models;
    using System.Collections.Generic;

    public class SearchedBookingResponse
    {
        public List<Booking> Bookings { get; set; }
        public int TotalRecords { get; set; }

    }
}
