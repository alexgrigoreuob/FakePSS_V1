using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using NS.Booking.Domain.Pax.Enums;

namespace NS.Booking.Domain.Pax.Models
{
    public class PaxTypeInfo
    {
        [JsonConverter(typeof(StringEnumConverter))]
        public PaxCategoryType Category { get; set; }

        public string Code { get; set; }
    }
}
