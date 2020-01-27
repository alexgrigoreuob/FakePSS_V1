using System.Collections.Generic;
using System.Linq;
using Newshore.Core.DDD.Concepts;
using Newtonsoft.Json;
using NS.Booking.Common.Domain.Charge.Enums;
using NS.Booking.Common.Domain._JsonConverters;

namespace NS.Booking.Common.Domain.PricedItem.Models
{
    [JsonConverter(typeof(PricedItemJsonConverter))]
    public class PricedItem : ValueObject
    {
        public PricedItem()
        {
            this.Charges = new List<Charge.Models.Charge>();
        }

        public string ReferenceId { get; set; }

        public decimal TotalAmount
        {
            get
            {
                var price = this.Charges.Where(x => x.Type != ChargeType.Discount).Sum(x => x.Amount);
                var discount = this.Charges.Where(x => x.Type == ChargeType.Discount).Sum(x => x.Amount);
                return price - discount;
            }
        }

        public string Currency => this.Charges.Any() ? this.Charges.First().Currency : string.Empty;

        public List<Charge.Models.Charge> Charges { get; set; }
    }
}