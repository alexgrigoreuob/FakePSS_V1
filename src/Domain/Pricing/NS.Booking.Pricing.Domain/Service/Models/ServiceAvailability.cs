namespace NS.Booking.Pricing.Domain.Service.Models
{
    public class ServiceAvailability
    {
        public string SellKey { get; set; }
        public bool IsInventoried { get; set; }
        public int AvailableUnits { get; set; }
        public int LimitPerPax { get; set; }
    }
}
