namespace NS.Booking.Pricing.Domain.Service.Models
{
    using Newshore.Core.NativeObjects.Extensions;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;
    using NS.Booking.Common.Domain.Charge.Models;
    using NS.Booking.Common.Domain.PricedItem.Enums;
    using System.Collections.Generic;
    using System.Linq;

    using NS.Booking.Common.Domain.Charge.Enums;

    public class Service
    {
        public Service()
        {
            Availability = new List<ServiceAvailability>();
            Charges = new List<Charge>();
        }

        public string Id
        {
            get
            {
                var value = $"{Info.Code}~{Info.Name}~{Info.Type}~{this.ReferenceId}" + string.Join("~", this.Availability.Select(availability => availability.SellKey));
                return value.EncodeHexadecimal();
            }
        }

        public string ReferenceId { get; set; }

        public ServiceInfo Info { get; set; }

        public List<ServiceAvailability> Availability { get; set; }

        public List<Charge> Charges { get; set; }

        [JsonConverter(typeof(StringEnumConverter))]
        public ProductScopeType SellType { get; set; }

        public decimal GetTotalAmount()
        {
            var discounts = this.Charges.Where(x => x.Type == ChargeType.Discount).ToList();
            var charges = this.Charges.Except(discounts);
            var price = charges.Sum(x => x.Amount);
            var discount = discounts.Sum(x => x.Amount);
            return price - discount;
        }
    }
}
