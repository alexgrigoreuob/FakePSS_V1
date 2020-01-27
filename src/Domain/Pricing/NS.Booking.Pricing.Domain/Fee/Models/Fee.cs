namespace NS.Booking.Pricing.Domain.Fee.Models
{
    using Newshore.Core.DDD.Concepts;
    using Newshore.Core.NativeObjects.Extensions;
    using NS.Booking.Common.Domain.Charge.Models;
    using NS.Booking.Common.Domain.PricedItem.Enums;
    using System.Collections.Generic;

    public class Fee : ValueObject
    {
        public string ReferenceId { get; set; }
        public string Code { get; set; }
        public string PaxId { get; set; }
        public List<Charge> Charges { get; set; }
        public ProductScopeType SellType { get; set; }
    }
}
