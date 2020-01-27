namespace NS.Booking.Pricing.Domain.Journey.Models.Responses
{
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;
    using NS.Booking.Pricing.Domain.Journey.Enums;
    using System;
    using System.Collections.Generic;

    public class Schedule
    {
        public DateTime Date { get; set; }

        [JsonConverter(typeof(StringEnumConverter))]
        public ScheduleAvailabilityType Availability { get; set; }

        public List<Journey> Journeys { get; set; }
    }
}