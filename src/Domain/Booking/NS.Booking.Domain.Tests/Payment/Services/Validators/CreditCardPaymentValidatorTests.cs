namespace NS.Booking.Domain.Tests.Payment.Services.Validators
{
    using NS.Booking.Common.Domain.Common.Validators;
    using NS.Booking.Domain.Payment.Enums;
    using NS.Booking.Domain.Payment.Exceptions;
    using NS.Booking.Domain.Payment.Models;
    using NS.Booking.Domain.Payment.Services.Validators;
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class CreditCardPaymentValidatorTests
    {
        private IValidator<CreditCardPayment> _validator;
        private CreditCardPayment _validCardPayment;

        [SetUp]
        public void Setup()
        {
            _validator = new CreditCardPaymentValidator();
            _validCardPayment = new CreditCardPayment
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
                VerifyCode = "123456"
            };
        }

        [Test]
        public void ThrowsWhenNullCardPayment()
        {
            Assert.Throws<InvalidCreditCardPaymentException>(() => _validator.Validate(null));
        }

        [TestCase(null, null, null)]
        [TestCase("", "", "")]
        [TestCase("Valid Name", "", "")]
        [TestCase("", "00000000000000", "123456")]
        [TestCase("Valid Name", "", "123456")]
        public void ThrowWhenInvalidCardHolderData(string cardHolder, string cardNumber, string verifyCode)
        {
            _validCardPayment.CardNumber = cardNumber;
            _validCardPayment.CardHolder = cardHolder;
            _validCardPayment.VerifyCode = verifyCode;

            Assert.Throws<InvalidCreditCardPaymentException>(() => _validator.Validate(_validCardPayment));
        }

        [TestCase(null, null)]
        [TestCase(1, 15)]
        [TestCase(0, 0)]
        [TestCase(2, 08)]
        [TestCase(0, 22)]
        [TestCase(15, 2022)]
        [TestCase(10, 2001)]
        public void ThrowWhenInvalidExpirationData(int expirationMonth, int expirationYear)
        {
            _validCardPayment.ExpirationMonth = expirationMonth;
            _validCardPayment.ExpirationYear = expirationYear;

            Assert.Throws<InvalidCreditCardPaymentException>(() => _validator.Validate(_validCardPayment));
        }

        [Test]
        public void DoesNotThrowWhenValidCardPayment()
        {
            Assert.DoesNotThrow(() => _validator.Validate(_validCardPayment));
        }
    }
}
