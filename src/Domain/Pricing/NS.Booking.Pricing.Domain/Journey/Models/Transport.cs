namespace NS.Booking.Pricing.Domain.Journey.Models
{
    using Newshore.Core.DDD.Concepts;

    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    using NS.Booking.Pricing.Domain.Journey.Enums;

    public class Transport : ValueObject
    {
        public Carrier Carrier { get; set; }

        [JsonConverter(typeof(StringEnumConverter))]
        public TransportType Type { get; set; }

        public string Name { get; set; }

        public string Model { get; set; }

        public string Manufacturer { get; set; }

        public string Number { get; set; }
    }
}