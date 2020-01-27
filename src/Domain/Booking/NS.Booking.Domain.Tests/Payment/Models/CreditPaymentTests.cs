namespace NS.Booking.Domain.Tests.Payment.Models
{
    using NS.Booking.Domain.Payment.Enums;
    using NS.Booking.Domain.Payment.Exceptions;
    using NS.Booking.Domain.Payment.Models;
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class CreditPaymentTests
    {
        private CreditPayment _validCreditPayment;
        private CreditPayment _invalidCreditPayment;

        [SetUp]
        public void SetUp()
        {
            _invalidCreditPayment = new CreditPayment();
            _validCreditPayment = new CreditPayment
            {
                Amount = 10,
                Currency = "EUR",
                PaymentDate = DateTime.Now,
                PaymentType = PaymentType.AgencyAccount,
                Status = PaymentStatus.Pending,
                Credit = 100,
                AccountNumber = "41275323"
            };
        }

        [Test]
        public void ShouldReturnInvalidPaymentException()
        {
            Assert.Throws<InvalidPaymentException>(() => _invalidCreditPayment.Validate());
        }

        [Test]
        public void ShouldReturnInvalidCreditPaymentException()
        {
            _validCreditPayment.Credit = 0;
            Assert.Throws<InvalidCreditPaymentException>(() => _validCreditPayment.Validate());
        }

        [Test]
        public void ShouldReturnNewValidPayment()
        {
            _validCreditPayment.Validate();
        }
    }
}
