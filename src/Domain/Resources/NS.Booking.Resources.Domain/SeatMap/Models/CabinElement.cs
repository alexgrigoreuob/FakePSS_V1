namespace NS.Booking.Resources.Domain.SeatMap.Models
{
    using Newshore.Core.DDD.Concepts;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;
    using NS.Booking.Resources.Domain.SeatMap.Enums;

    public class CabinElement : ValueObject
    {
        [JsonConverter(typeof(StringEnumConverter))]
        public CabinElementType Type { get; set; }

        public int Spaces { get; set; }

        public SeatInfo SeatInfo { get; set; }
    }
}
