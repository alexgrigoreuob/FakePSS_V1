namespace NS.Booking.Pricing.Domain.Service.Models
{
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;
    using NS.Booking.Common.Domain.Service.Enums;

    public class ServiceInfo
    {
        public string Code { get; set; }

        [JsonConverter(typeof(StringEnumConverter))]
        public ServiceType Type { get; set; }

        public string Name { get; set; }

        public string Category { get; set; }
    }
}
