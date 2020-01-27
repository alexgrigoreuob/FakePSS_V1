namespace NS.Booking.Domain.Checkin.Models.Responses
{
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;
    using NS.Booking.Domain.Checkin.Enums;
    using System.Collections.Generic;

    public class SegmentCheckinStatusResponse
    {
        public SegmentCheckinStatusResponse()
        {
            this.Pax = new List<SegmentPaxInfo>();
        }

        public string SegmentId { get; set; }

        public List<SegmentPaxInfo> Pax { get; set; }

        [JsonConverter(typeof(StringEnumConverter))]
        public CheckinStatus Status { get; set; }
    }
}
