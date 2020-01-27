namespace NS.Booking.Pricing.Domain.Journey.Models
{
    using Newshore.Core.DDD.Concepts;
    using Newshore.Core.NativeObjects.Extensions;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;
    using NS.Booking.Pricing.Domain.Journey.Enums;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Journey : AggregateRoot
    {
        public Journey()
        {
            this.Fares = new List<Fare>();
        }

        public string Origin => this.Segments.Any() ? this.Segments.First().Origin : string.Empty;

        public string Destination => this.Segments.Any() ? this.Segments.Last().Destination : string.Empty;

        public DateTime STD => this.Segments.Any() ? this.Segments.First().STD : DateTime.MinValue;

        public DateTime STDUTC => this.Segments.Any() ? this.Segments.First().STDUTC : DateTime.MinValue;

        public DateTime STA => this.Segments.Any() ? this.Segments.Last().STA : DateTime.MinValue;

        public DateTime STAUTC => this.Segments.Any() ? this.Segments.Last().STAUTC : DateTime.MinValue;

        public TimeSpan Duration => this.STAUTC - this.STDUTC;

        //Internal Infrastructure ID
        public string ReferenceId { get; set; }

        [JsonConverter(typeof(StringEnumConverter))]
        public AvailabilityRequestType ScheduleType { get; set; }

        public List<Segment> Segments { get; set; }

        public List<Fare> Fares { get; set; }

        public override string Id
        {
            get
            {
                var referenceId = string.IsNullOrEmpty(this.ReferenceId)
                                      ? string.Empty
                                      : this.ReferenceId.EncodeHexadecimal();

                var value = string.Join("~", this.Segments.Select(segment => segment.Id)) + $"~{referenceId}";
                return value.EncodeHexadecimal();
            }
        }
    }
}