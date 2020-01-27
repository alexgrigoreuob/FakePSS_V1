namespace NS.Booking.Domain.Payment.Models
{
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;
    using NS.Booking.Domain.Payment.Enums;

    public class PaymentDomainServiceBase
    {
        [JsonConverter(typeof(StringEnumConverter))]
        public PaymentType Type { get; set; }

        public string Method { get; set; }
    }
}
