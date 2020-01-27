namespace NS.Booking.Resources.Domain.SeatMap.Models
{
    using Newshore.Core.DDD.Concepts;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;
    using NS.Booking.Resources.Domain.SeatMap.Enums;

    public class SeatProperty : ValueObject
    {
        [JsonConverter(typeof(StringEnumConverter))]
        public SeatPropertyType Type { get; set; }

        public bool Value { get; set; }
    }
}
