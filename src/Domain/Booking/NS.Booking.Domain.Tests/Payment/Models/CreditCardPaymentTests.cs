namespace NS.Booking.Domain.Tests.Payment.Models
{
    using NS.Booking.Domain.Payment.Enums;
    using NS.Booking.Domain.Payment.Exceptions;
    using NS.Booking.Domain.Payment.Models;
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class CreditCardPaymentTests
    {
        private CreditCardPayment _validCreditCardPayment;
        private CreditCardPayment _invalidCreditCardPayment;

        [SetUp]
        public void Setup()
        {
            _invalidCreditCardPayment = new CreditCardPayment();
            _validCreditCardPayment = new CreditCardPayment
            {
                Amount = 10,
                CardHolder = "Pepito Flores",
                CardNumber = "4111111111111111",
                Currency = "EUR",
                ExpirationMonth = 12,
                ExpirationYear = 22,
                PaymentDate = DateTime.Now,
                PaymentMethod = "VI",
                PaymentType = PaymentType.CreditCard,
                Status = PaymentStatus.Pending,
                VerifyCode = "123"
            };
        }

        [Test]
        public void ShouldReturnInvalidPaymentException()
        {
            Assert.Throws<InvalidPaymentException>(() => _invalidCreditCardPayment.Validate());
        }

        public void ShouldReturnInvalidCreditCardPaymentException()
        {
            _validCreditCardPayment.CardNumber = null;
            Assert.Throws<InvalidCreditCardPaymentException>(() => _validCreditCardPayment.Validate());
        }

        public void ShouldReturnNewValidCreditCardPayment()
        {
            _validCreditCardPayment.Validate();
        }
    }
}
