namespace NS.Booking.Domain.Booking.Models
{
    using Newshore.Core.DDD.Concepts;
    using NS.Booking.Common.Domain.PricedItem.Enums;
    using NS.Booking.Common.Domain.PricedItem.Models;
    using NS.Booking.Domain.Payment.Enums;
    using System.Collections.Generic;
    using System.Linq;

    public class BookingPricing : ValueObject
    {
        private readonly Booking booking;

        public BookingPricing(Booking booking)
        {
            this.booking = booking;
            this.Breakdown = new Dictionary<ProductScopeType, List<PricedItem>>();
        }

        public decimal TotalAmount
        {
            get
            {
                return this.Breakdown.Sum(x => x.Value.Sum(y => y.TotalAmount));
            }
        }

        public decimal BalanceDue
        {
            get
            {
                return this.TotalAmount - this.booking.Payments
                           .Where(payment => payment.Status == PaymentStatus.Approved || payment.Status == PaymentStatus.Pending)
                           .Sum(x => x.Amount);
            }
        }

        public bool IsBalanced => (this.TotalAmount - this.booking.Payments
            .Where(payment => payment.Status == PaymentStatus.Approved).Sum(x => x.Amount)) == decimal.Zero;

        private string _currency;

        public string Currency
        {
            get
            {
                if (this.Breakdown.Any() && this.Breakdown.First().Value.Any())
                {
                    return this.Breakdown.First().Value.First().Currency;
                }


                return string.IsNullOrEmpty(this._currency) ? string.Empty : this._currency;
            }
            set
            {
                this._currency = value;
            }
        }

        public Dictionary<ProductScopeType, List<PricedItem>> Breakdown { get; }

        public void AddBreakdownItem(ProductScopeType scope, PricedItem pricedItem)
        {
            if (this.Breakdown.Keys.Contains(scope))
            {
                this.Breakdown.First(x => x.Key == scope).Value.Add(pricedItem);
            }
            else
            {
                this.Breakdown.Add(scope, new List<PricedItem> { pricedItem });
            }
        }
    }
}