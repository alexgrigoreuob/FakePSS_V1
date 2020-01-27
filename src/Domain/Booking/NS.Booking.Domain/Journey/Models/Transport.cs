namespace NS.Booking.Domain.Journey.Models
{
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;
    using NS.Booking.Domain.Journey.Enums;

    public class Transport
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