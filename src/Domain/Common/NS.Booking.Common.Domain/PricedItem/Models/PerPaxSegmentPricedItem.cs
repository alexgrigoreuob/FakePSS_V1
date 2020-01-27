namespace NS.Booking.Common.Domain.PricedItem.Models
{
    public class PerPaxSegmentPricedItem : PricedItem
    {
        public string PaxId { get; set; }

        public string SegmentId { get; set; }
    }
}