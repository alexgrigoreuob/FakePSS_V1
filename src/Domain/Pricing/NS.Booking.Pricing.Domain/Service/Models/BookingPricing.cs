namespace NS.Booking.Pricing.Domain.Service.Models
{
    using NS.Booking.Pricing.Domain.Journey.Models;
    using System.Collections.Generic;

    public class BookingPricing
    {
        public List<Journey> Journeys { get; set; }
        public string Currency { get; set; }
    }
}
