namespace NS.Booking.Domain.Payment.Models
{
    using Newshore.Core.DDD.Concepts;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;
    using NS.Booking.Domain.Payment.Enums;

    public class DccInfo : ValueObject
    {
        public DccInfo()
        {
            DccStatus = DccStatus.NotOffered;
        }

        [JsonConverter(typeof(StringEnumConverter))]
        public DccStatus DccStatus { get; set; }

        public string ForeignCurrencyCode { get; set; }

        public decimal ForeignAmount { get; set; }

        public decimal ForeignExchangeRate { get; set; }
    }
}
