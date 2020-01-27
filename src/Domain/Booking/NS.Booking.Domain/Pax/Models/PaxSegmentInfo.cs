namespace NS.Booking.Domain.Pax.Models
{
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;
    using NS.Booking.Domain.Pax.Enums;

    public class PaxSegmentInfo
    {
        public string SegmentId { get; set; }

        [JsonConverter(typeof(StringEnumConverter))]
        public PaxStatus Status { get; set; }

        public string Seat { get; set; }

        public string BoardingSequence { get; set; }
    }
}
