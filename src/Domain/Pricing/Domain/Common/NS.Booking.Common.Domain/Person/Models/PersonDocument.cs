namespace NS.Booking.Common.Domain.Person.Models
{
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;
    using NS.Booking.Common.Domain._JsonConverters;
    using NS.Booking.Common.Domain.Person.Enums;
    using System;

    public class PersonDocument
    {
        [JsonConverter(typeof(StringEnumConverter))]
        public DocumentType Type { get; set; }

        public string Number { get; set; }

        public string IssuedCountry { get; set; }

        public string Nationality { get; set; }

        [JsonConverter(typeof(CustomDateTimeConverter), "yyyy-MM-dd")]
        public DateTime ExpirationDate { get; set; }
    }
}
