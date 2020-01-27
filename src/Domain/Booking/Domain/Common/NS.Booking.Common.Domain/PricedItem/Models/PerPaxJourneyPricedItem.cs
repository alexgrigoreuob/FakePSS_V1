namespace NS.Booking.Common.Domain.PricedItem.Models
{
    public class PerPaxJourneyPricedItem : PricedItem
    {
        public string PaxId { get; set; }

        public string JourneyId { get; set; }
    }
}