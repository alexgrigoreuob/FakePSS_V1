namespace NS.Booking.Domain.Payment.Models
{
    using Newshore.Core.DDD.Concepts;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;
    using NS.Booking.Common.Domain.Charge.Models;
    using NS.Booking.Domain.Payment.Enums;

    public class PaymentMethod : ValueObject
    {
        [JsonConverter(typeof(StringEnumConverter))]
        public PaymentType Type { get; set; }

        public string Method { get; set; }

        public string Currency { get; set; }

        /// <summary>
        /// Charge demanded for using this payment method.
        /// </summary>
        public Charge Charge { get; set; }

        /// <summary>
        /// Indicates whether Direct Currency Conversion is available. Only for Credit Card payments.
        /// </summary>
        public bool DccAllowed { get; set; }
    }
}
