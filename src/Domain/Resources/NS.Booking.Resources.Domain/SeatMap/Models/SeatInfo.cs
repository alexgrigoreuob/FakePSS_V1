namespace NS.Booking.Resources.Domain.SeatMap.Models
{
    using Newshore.Core.DDD.Concepts;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;
    using NS.Booking.Resources.Domain.SeatMap.Enums;
    using System.Collections.Generic;

    public class SeatInfo : ValueObject
    {
        public string SeatNumber { get; set; }

        public string Column { get; set; }

        public int Row { get; set; }

        public string Category { get; set; }

        [JsonConverter(typeof(StringEnumConverter))]
        public SeatAvailability Availability { get; set; }

        public List<SeatProperty> Properties { get; set; }
    }
}
