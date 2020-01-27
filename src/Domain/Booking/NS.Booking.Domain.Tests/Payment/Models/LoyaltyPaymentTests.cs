namespace NS.Booking.Domain.Tests.Payment.Models
{
    using NS.Booking.Domain.Payment.Enums;
    using NS.Booking.Domain.Payment.Exceptions;
    using NS.Booking.Domain.Payment.Models;
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class LoyaltyPaymentTests
    {
        private LoyaltyPayment _validLoyaltyPayment;
        private LoyaltyPayment _invalidLoyaltyPayment;

        [SetUp]
        public void SetUp()
        {
            _invalidLoyaltyPayment = new LoyaltyPayment();
            _validLoyaltyPayment = new LoyaltyPayment
            {
                Amount = 10,
                Currency = "EUR",
                PaymentDate = DateTime.Now,
                PaymentType = PaymentType.Loyalty,
                Status = PaymentStatus.Pending,
                Points = 100
            };
        }

        [Test]
        public void ShouldReturnInvalidPaymentException()
        {
            Assert.Throws<InvalidPaymentException>(() => _invalidLoyaltyPayment.Validate());
        }

        [Test]
        public void ShouldReturnInvalidLoyaltyPaymentException()
        {
            _validLoyaltyPayment.Points = 0;
            Assert.Throws<InvalidLoyaltyPaymentException>(() => _validLoyaltyPayment.Validate());
        }

        [Test]
        public void ShouldReturnNewValidPayment()
        {
            _validLoyaltyPayment.Validate();
        }
    }
}
