namespace NS.Booking.Infrastructure.Fake.Resources.SeatMap.Models.Configuration
{
    using System.Collections.Generic;

    public class ConfigCabin
    {
        public int Number { get; set; }

        public string ClassType { get; set; }

        public List<ConfigCabinDistribution> Distributions { get; set; }
    }
}
