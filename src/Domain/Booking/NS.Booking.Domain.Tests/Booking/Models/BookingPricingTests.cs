using NS.Booking.Common.Domain.PricedItem.Enums;
using NS.Booking.Common.Domain.PricedItem.Models;

namespace NS.Booking.Domain.Tests.Booking.Models
{
    using System.Collections.Generic;
    using System.Linq;
    
    using NS.Booking.Domain.Booking.Models;
    using NS.Booking.Domain.Payment.Enums;
    using NS.Booking.Domain.Payment.Models;
    using NS.Booking.Common.Domain.Charge.Models;

    using NUnit.Framework;

    [TestFixture]
    public class BookingPricingTests
    {
        private Booking booking;
        private BookingPricing bookingPricing;

        [SetUp]
        public void SetUp()
        {
            this.booking = new Booking();
            this.bookingPricing = new BookingPricing(booking);
        }

        [Test]
        public void TotalAmountIsZeroWhenNoCharges()
        {
            Assert.AreEqual(decimal.Zero, this.bookingPricing.TotalAmount);
        }

        [Test]
        public void TotalAmountIsCalculatedCorrectlyBasedOnCharges()
        {
            this.bookingPricing.Breakdown.Add(
                ProductScopeType.PerBooking,
                new List<PricedItem> { new PerBookingPricedItem { Charges = this.AddCharges(4) } });
            this.bookingPricing.Breakdown.Add(
                ProductScopeType.PerPax,
                new List<PricedItem> { new PerPaxPricedItem { Charges = this.AddCharges(1) } });
            this.bookingPricing.Breakdown.Add(
                ProductScopeType.PerPaxJourney,
                new List<PricedItem> { new PerPaxJourneyPricedItem { Charges = this.AddCharges(3) } });
            this.bookingPricing.Breakdown.Add(
                ProductScopeType.PerPaxSegment,
                new List<PricedItem> { new PerPaxSegmentPricedItem { Charges = this.AddCharges(1) } });
            this.bookingPricing.Breakdown.Add(
                ProductScopeType.PerSegment,
                new List<PricedItem> { new PerSegmentPricedItem { Charges = this.AddCharges(2) } });

            Assert.IsTrue(this.bookingPricing.TotalAmount > 0);
            Assert.AreEqual(this.bookingPricing.Breakdown.SelectMany(x => x.Value).Sum(x => x.Charges.Count), this.bookingPricing.TotalAmount);
        }

        [Test]
        public void IsBalancedIsTrueWhenNoBalanceDue()
        {
            Assert.IsTrue(this.bookingPricing.IsBalanced);
        }

        [Test]
        public void IsBalancedIsFalseWhenBalanceDueIsGreaterThanZero()
        {
            this.bookingPricing.Breakdown.Add(
                ProductScopeType.PerSegment,
                new List<PricedItem> { new PerSegmentPricedItem { Charges = this.AddCharges(2) } });
            Assert.IsFalse(this.bookingPricing.IsBalanced);
        }

        [Test]
        public void CurrencyIsNotSetWhenNoCharge()
        {
            Assert.AreEqual(this.bookingPricing.Currency, string.Empty);
        }

        [Test]
        public void CurrencyIsSetWhenThereAreCharges()
        {
            this.bookingPricing.Breakdown.Add(
                ProductScopeType.PerSegment,
                new List<PricedItem> { new PerSegmentPricedItem { Charges = this.AddCharges(2) } });
            Assert.AreEqual(this.bookingPricing.Currency, this.bookingPricing.Breakdown.SelectMany(x => x.Value).Select(x => x.Currency).First());
        }

        [Test]
        public void BalanceDueIsHigherThanZeroWhenPaymentsDoNotCoverTotalAmount()
        {
            this.bookingPricing.Breakdown.Add(
                ProductScopeType.PerSegment,
                new List<PricedItem> { new PerSegmentPricedItem { Charges = this.AddCharges(1) } });
            Assert.IsTrue(this.bookingPricing.BalanceDue > 0);
        }

        [Test]
        public void BalanceDueIsZeroWhenPaymentsCoverTotalAmount()
        {
            this.bookingPricing.Breakdown.Add(
                ProductScopeType.PerSegment,
                new List<PricedItem> { new PerSegmentPricedItem { Charges = this.AddCharges(1) } });
            this.booking.Payments.Add(new CreditCardPayment
                                          {
                                              Amount = 1,
                                              Status = PaymentStatus.Approved
                                          });
            Assert.IsTrue(this.bookingPricing.BalanceDue == 0);
        }

        [Test]
        public void BalanceDueSumsApprovedAndPendingPayments()
        {
            this.bookingPricing.Breakdown.Add(
                ProductScopeType.PerSegment,
                new List<PricedItem> { new PerSegmentPricedItem { Charges = this.AddCharges(2) } });
            this.booking.Payments.Add(new CreditCardPayment
                                          {
                                              Amount = 1,
                                              Status = PaymentStatus.Approved
                                          });
            this.booking.Payments.Add(new CreditCardPayment
                                          {
                                              Amount = 1,
                                              Status = PaymentStatus.Pending
                                          });
            this.booking.Payments.Add(new CreditCardPayment
                                          {
                                              Amount = 1,
                                              Status = PaymentStatus.Declined
                                          });
            Assert.IsTrue(this.bookingPricing.BalanceDue == 0);
        }

        [Test]
        public void BalanceDueIsNegativeWhenPaymentsAreHigherTotalAmount()
        {
            this.bookingPricing.Breakdown.Add(
                ProductScopeType.PerSegment,
                new List<PricedItem> { new PerSegmentPricedItem { Charges = this.AddCharges(1) } });
            this.booking.Payments.Add(new CreditCardPayment
                                          {
                                              Amount = 2,
                                              Status = PaymentStatus.Approved
                                          });
            Assert.IsTrue(this.bookingPricing.BalanceDue < 0);
        }

        private List<Charge> AddCharges(int totalCharges)
        {
            var charges = new List<Charge>();
            for (var i = 0; i < totalCharges; i++)
            {
                charges.Add(new Charge { Amount = 1, Currency = "Currency" });
            }

            return charges;
        }
    }
}