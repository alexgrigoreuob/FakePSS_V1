namespace NS.Booking.Domain.Journey.Models
{
    using Newshore.Core.DDD.Concepts;
    using Newshore.Core.NativeObjects.Extensions;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;
    using NS.Booking.Domain.Checkin.Enums;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Segment : Aggregate
    {
        public override string Id
        {
            get
            {
                var referenceId = string.IsNullOrEmpty(this.ReferenceId) ? string.Empty : this.ReferenceId.EncodeHexadecimal();
                var value = $"{this.Legs.First().Origin}~{this.Legs.Last().Destination}~{this.Transport.Number}~" +
                    $"{this.Transport.Carrier.Code}~{this.Legs.First().STD:yyyy-MM-dd}~{referenceId}";
                return value.EncodeHexadecimal();
            }
        }

        //Internal Infrastructure ID
        public string ReferenceId { get; set; }

        public string Origin => this.Legs.Any() ? this.Legs.First().Origin : string.Empty;

        public string Destination => this.Legs.Any() ? this.Legs.Last().Destination : string.Empty;

        public DateTime STD => this.Legs.Any() ? this.Legs.First().STD : DateTime.MinValue;

        public DateTime STDUTC => this.Legs.Any() ? this.Legs.First().STDUTC : DateTime.MinValue;

        public DateTime STA => this.Legs.Any() ? this.Legs.Last().STA : DateTime.MinValue;

        public DateTime STAUTC => this.Legs.Any() ? this.Legs.Last().STAUTC : DateTime.MinValue;

        public TimeSpan Duration => this.STAUTC - this.STDUTC;

        public string DepartureGate { get; set; }

        public List<Leg> Legs { get; set; }

        public Transport Transport { get; set; }

        [JsonConverter(typeof(StringEnumConverter))]
        public CheckinStatus Status { get; set; }
    }
}
