namespace NS.Booking.Resources.Domain.SeatMap.Models
{
    using Newshore.Core.DDD.Concepts;
    using System.Collections.Generic;

    public class CabinDistribution : ValueObject
    {
        public int RowMin { get; set; }

        public int RowMax { get; set; }

        public List<CabinSector> Sectors { get; set; }

        public CabinElement[,] SeatMap { get; set; }
    }
}
