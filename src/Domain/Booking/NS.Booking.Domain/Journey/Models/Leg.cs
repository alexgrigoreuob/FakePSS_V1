namespace NS.Booking.Domain.Journey.Models
{
    using Newshore.Core.DDD.Concepts;
    using System;

    public class Leg : ValueObject
    {
        public string Origin { get; set; }

        public string Destination { get; set; }

        public string OriginTerminal { get; set; }

        public string DestinationTerminal { get; set; }

        public DateTime STD { get; set; }

        public DateTime STDUTC { get; set; }

        public DateTime STA { get; set; }

        public DateTime STAUTC { get; set; }

        public TimeSpan Duration { get; set; }

        public LegInfo LegInfo { get; set; }
    }
}
