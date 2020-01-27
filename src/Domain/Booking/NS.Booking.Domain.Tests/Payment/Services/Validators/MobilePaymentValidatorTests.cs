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
    public class MobilePaymentValidatorTests
    {
        private IValidator<MobilePayment> _validator;
        private MobilePayment _validCardPayment;

        [SetUp]
        public void Setup()
        {
            _validator = new MobilePaymentValidator();
            _validCardPayment = new MobilePayment
            {
                Amount = 10,
                Currency = "EUR",
                PaymentDate = DateTime.Now,
                PaymentType = PaymentType.CreditCard,
                Status = PaymentStatus.Pending,
                Country = "ES",
                Operator = "NS",
                Phone = "123456789",
                Prefix = "004"
            };
        }

        [Test]
        public void ThrowsWhenNullCardPayment()
        {
            Assert.Throws<InvalidMobilePaymentException>(() => _validator.Validate(null));
        }

        [TestCase(null, null, null, null)]
        [TestCase("", "", "", "")]
        [TestCase("ES", "", "", "")]
        [TestCase("", "NS", "001", "")]
        [TestCase("ES", "", "001", "")]
        [TestCase("ES", "NS", "001", "")]
        [TestCase("", "NS", "001", "123456789")]
        [TestCase("", "", "001", "123456789")]
        [TestCase("", "", "", "123456789")]
        [TestCase("", "", null, null)]
        [TestCase(null, null, "001", "123456789")]
        public void ThrowWhenInvalidCardHolderData(string country, string operatorName, string prefix, string phone)
        {
            this._validCardPayment.Country = country;
            this._validCardPayment.Operator = operatorName;
            this._validCardPayment.Prefix = prefix;
            this._validCardPayment.Phone = phone;

            Assert.Throws<InvalidMobilePaymentException>(() => _validator.Validate(_validCardPayment));
        }

        [Test]
        public void DoesNotThrowWhenValidCardPayment()
        {
            Assert.DoesNotThrow(() => _validator.Validate(_validCardPayment));
        }
    }
}
