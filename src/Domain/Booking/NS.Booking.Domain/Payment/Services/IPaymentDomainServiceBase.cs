namespace NS.Booking.Domain.Payment.Services
{
    using Newshore.Core.DDD.Concepts;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;
    using NS.Booking.Domain.Payment.Enums;
    using System.Collections.Generic;

    public interface IPaymentDomainServiceBase : IDomainService
    {
        List<string> SupportedMethods { get; }

        [JsonConverter(typeof(StringEnumConverter))]
        PaymentType SupportedType { get; }
    }
}