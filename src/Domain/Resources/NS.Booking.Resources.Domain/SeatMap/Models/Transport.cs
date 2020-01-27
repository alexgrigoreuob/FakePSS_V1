namespace NS.Booking.Resources.Domain.SeatMap.Models
{
    using Newshore.Core.DDD.Concepts;
    using Newshore.Core.NativeObjects.Extensions;
    using System.Collections.Generic;

    public class Transport : Aggregate
    {
        public override string Id
        {
            get
            {
                 var value = $"{this.Segment.SegmentId}~{this.Type}~{this.Sufix}";
                return value.EncodeHexadecimal();
            }
        }

        public Segment Segment { get; set; }

        public string Type { get; set; }

        public string Sufix { get; set; }

        public List<Deck> Decks;
    }
}
