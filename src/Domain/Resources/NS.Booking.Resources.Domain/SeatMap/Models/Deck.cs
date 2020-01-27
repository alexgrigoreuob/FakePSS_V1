namespace NS.Booking.Resources.Domain.SeatMap.Models
{
    using Newshore.Core.DDD.Concepts;
    using System.Collections.Generic;

    public class Deck : ValueObject
    {
        public int Number { get; set; }

        public List<Cabin> Cabins { get; set; }
    }
}
