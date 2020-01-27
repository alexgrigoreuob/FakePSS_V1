namespace NS.Booking.Common.Domain.Person.Models
{
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;
    using NS.Booking.Common.Domain._JsonConverters;
    using NS.Booking.Common.Domain.Person.Enums;
    using System;

    public class PersonInfo
    {
        [JsonConverter(typeof(StringEnumConverter))]
        public GenderType Gender { get; set; }

        [JsonConverter(typeof(StringEnumConverter))]
        public WeightType Weight { get; set; }

        [JsonConverter(typeof(CustomDateTimeConverter), "yyyy-MM-dd")]
        public DateTime DateOfBirth { get; set; }

        public string Nationality { get; set; }
    }
}
