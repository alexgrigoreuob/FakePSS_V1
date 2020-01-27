namespace NS.Booking.Domain.Booking.Models
{
    using Newshore.Core.DDD.Concepts;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;
    using NS.Booking.Domain.Booking.Enums;

    public class Comment : ValueObject
    {
        [JsonConverter(typeof(StringEnumConverter))]
        public CommentType Type { get; set; }
        public string Data { get; set; }
    }
}
