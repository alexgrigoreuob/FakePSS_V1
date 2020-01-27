namespace NS.Booking.Common.Domain.Charge.Models
{
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;
    using NS.Booking.Common.Domain.Charge.Enums;

    public class Charge
    {
        [JsonConverter(typeof(StringEnumConverter))]
        public ChargeType Type { get; set; }

        public string Code { get; set; }

        public decimal Amount { get; set; }

        public string Currency { get; set; }
    }
}
