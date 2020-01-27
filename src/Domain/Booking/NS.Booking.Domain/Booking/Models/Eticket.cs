namespace NS.Booking.Domain.Booking.Models
{
    using Newshore.Core.DDD.Concepts;

    using NS.Booking.Common.Domain.PricedItem.Enums;

    public class Eticket : ValueObject
    {
        public string PaxId { get; set; }

        public string SellKey { get; set; }

        public ProductScopeType Scope { get; set; }

        public string Code { get; set; }
    }
}