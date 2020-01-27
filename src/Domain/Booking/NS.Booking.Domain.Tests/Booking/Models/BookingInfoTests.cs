using NS.Booking.Common.Domain.PricedItem.Enums;
using NS.Booking.Common.Domain.PricedItem.Models;

namespace NS.Booking.Domain.Tests.Booking.Models
{
    using System.Collections.Generic;

    using NS.Booking.Domain.Booking.Enums;
    using NS.Booking.Domain.Booking.Models;
    using NS.Booking.Domain.Payment.Enums;
    using NS.Booking.Domain.Payment.Models;
    using NS.Booking.Common.Domain.Charge.Models;

    using NUnit.Framework;

    [TestFixture]
    public class BookingInfoTests
    {
        [Test]
        public void StatusIsCreatingWhenNoRecordLocator()
        {
            var booking = new Booking();
            Assert.AreEqual(booking.BookingInfo.Status, BookingStatus.Creating);
        }

        [Test]
        public void StatusIsConfimedWhenBookingIsBalanced()
        {
            var booking = new Booking { BookingInfo = { RecordLocator = "RecordLocator" } };
            booking.Pricing.Breakdown.Add(
                ProductScopeType.PerBooking,
                new List<PricedItem>
                    {
                        new PerBookingPricedItem
                            {
                                Charges =
                                    new List<Charge> { new Charge { Amount = 1 } }
                            }
                    });
            booking.Payments.Add(new CreditCardPayment{Amount = 1, Status = PaymentStatus.Approved});
            Assert.AreEqual(booking.BookingInfo.Status, BookingStatus.Confirmed);
        }

        [Test]
        public void StatusIsConfirmedWhenBalanceDueIsNegative()
        {
            var booking = new Booking { BookingInfo = { RecordLocator = "RecordLocator" } };
            booking.Pricing.Breakdown.Add(
                ProductScopeType.PerBooking,
                new List<PricedItem>
                    {
                        new PerBookingPricedItem
                            {
                                Charges =
                                    new List<Charge> { new Charge { Amount = 1 } }
                            }
                    });
            booking.Payments.Add(new CreditCardPayment { Amount = 2, Status = PaymentStatus.Approved });
            Assert.AreEqual(booking.BookingInfo.Status, BookingStatus.Confirmed);
        }

        [Test]

        public void StatusIsHoldWhenThereIsPositiveBalanceDue()
        {
            var booking = new Booking { BookingInfo = { RecordLocator = "RecordLocator" } };
            booking.Pricing.Breakdown.Add(
                ProductScopeType.PerBooking,
                new List<PricedItem>
                    {
                        new PerBookingPricedItem
                            {
                                Charges =
                                    new List<Charge> { new Charge { Amount = 2 } }
                            }
                    });
            booking.Payments.Add(new CreditCardPayment { Amount = 1, Status = PaymentStatus.Approved });
            Assert.AreEqual(booking.BookingInfo.Status, BookingStatus.Hold);
        }
    }
}