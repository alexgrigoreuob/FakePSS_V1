namespace NS.Booking.Domain.Journey.Models
{
    using Newshore.Core.NativeObjects.Extensions;
    using NS.Booking.Common.Domain.Charge.Models;
    using System.Collections.Generic;

    using Newshore.Core.DDD.Concepts;
    using System.Linq;

    public class Fare : Aggregate
    {
        public Fare()
        {
            this.Charges = new List<Charge>();
        }
        
        public override string Id
        {
            get
            {
                var referenceId = string.IsNullOrEmpty(this.ReferenceId)
                                      ? string.Empty
                                      : this.ReferenceId.EncodeHexadecimal();
                var value = $"{this.ProductClass}~{this.FareBasisCode}~{this.ClassOfService}~{this.PaxCode}~{this.PromoCode}~{referenceId}";
                return value.EncodeHexadecimal();
            }
        }

        //Internal Infrastructure ID
        public string ReferenceId { get; set; }

        public string FareBasisCode { get; set; }

        public string ClassOfService { get; set; }

        public string ProductClass { get; set; }

        public int AvailableSeats { get; set; }

        public string PaxCode { get; set; }

        public string PromoCode { get; set; }

        public decimal TotalAmount
        {

            get
            {
                var totalDiscount = this.Charges.Where(w => w.Type == Common.Domain.Charge.Enums.ChargeType.Discount).Sum(x => x.Amount);
                var totalCharges = this.Charges.Where(w => w.Type != Common.Domain.Charge.Enums.ChargeType.Discount).Sum(x => x.Amount);
                return totalCharges - totalDiscount;
            }

        }
        public List<Charge> Charges { get; set; }
    }
}
