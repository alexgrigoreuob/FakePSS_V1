namespace NS.Booking.Common.Domain.Person.Models
{
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    using NS.Booking.Common.Domain.Person.Enums;

    public class PersonName
    {
        [JsonConverter(typeof(StringEnumConverter))]
        public TitleType Title { get; set; }
        public string First { get; set; }
        public string Middle { get; set; }
        public string Last { get; set; }
    }
}
