namespace NS.Booking.Infrastructure.Fake.Resources.SeatMap.Models.Configuration
{
    using System.Collections.Generic;

    public class ConfigCabinDistribution
    {
        public int Number { get; set; }

        public int RowTo { get; set; }

        public int RowFrom { get; set; }

        public string Sectors { get; set; }

        public List<ConfigCabinElement> Positions { get; set; }
    }
}
