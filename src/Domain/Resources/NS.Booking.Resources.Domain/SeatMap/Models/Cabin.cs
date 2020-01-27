namespace NS.Booking.Resources.Domain.SeatMap.Models
{
    using Newshore.Core.DDD.Concepts;
    using System.Collections.Generic;

    public class Cabin : ValueObject
    {    
        public string ClassType { get; set; }

        public List<CabinDistribution> Distributions;
        
    }
}
