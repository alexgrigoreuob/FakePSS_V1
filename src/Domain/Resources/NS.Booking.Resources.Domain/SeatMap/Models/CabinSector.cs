namespace NS.Booking.Resources.Domain.SeatMap.Models
{
    using Newshore.Core.DDD.Concepts;
    using System.Collections.Generic;

    public class CabinSector : ValueObject
    {
        public int Number { get; set; }

        public List<string> Columns { get; set; }
    }
}
