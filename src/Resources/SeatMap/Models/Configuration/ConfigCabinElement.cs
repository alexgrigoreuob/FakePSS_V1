namespace NS.Booking.Infrastructure.Fake.Resources.SeatMap.Models.Configuration
{
    using NS.Booking.Resources.Domain.SeatMap.Enums;

    public class ConfigCabinElement
    {
        public int Spaces { get; set; }

        public int Column { get; set; }

        public int Row { get; set; }

        public CabinElementType Type { get; set; }
    }
}
