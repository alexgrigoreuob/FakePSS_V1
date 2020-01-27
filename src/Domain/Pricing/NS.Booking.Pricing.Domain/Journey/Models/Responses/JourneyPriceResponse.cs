namespace NS.Booking.Pricing.Domain.Journey.Models.Responses
{
    using System.Collections.Generic;

    public class JourneyPriceResponse
    {
        public string Id { get; set; }

        public string Currency { get; set; }

        public List<Schedule> Schedules { get; set; }
    }
}