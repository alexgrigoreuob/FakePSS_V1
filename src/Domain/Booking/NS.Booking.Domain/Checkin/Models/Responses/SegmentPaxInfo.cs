namespace NS.Booking.Domain.Checkin.Models.Responses
{
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;
    using NS.Booking.Domain.Pax.Enums;

    public class SegmentPaxInfo
    {
        public string PaxId { get; set; }

        [JsonConverter(typeof(StringEnumConverter))]
        public PaxStatus Status { get; set; }

        public string Seat { get; set; }

        public bool CanDownladBoardingPass
        {
            get
            {
                return this.Status == PaxStatus.CheckedIn;
            }
        }
    }
}
