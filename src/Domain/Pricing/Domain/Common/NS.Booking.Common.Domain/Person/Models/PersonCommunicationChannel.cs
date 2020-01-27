namespace NS.Booking.Common.Domain.Person.Models
{
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    using NS.Booking.Common.Domain.Person.Enums;

    public class PersonCommunicationChannel
    {
        [JsonConverter(typeof(StringEnumConverter))]
        public ChannelType Type { get; set; }

        public string Info { get; set; }

        public string Prefix { get; set; }

        public string CultureCode { get; set; }
    }
}
