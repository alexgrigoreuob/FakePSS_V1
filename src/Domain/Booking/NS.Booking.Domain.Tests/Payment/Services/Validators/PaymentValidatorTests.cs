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
    public class PaymentValidatorTests
    {
        private IValidator<Payment> _validator;
        private Payment _validPayment;

        [SetUp]
        public void Setup()
        {
            _validator = new PaymentValidator();
            _validPayment = new Payment
            {
                Amount = 10,
                Currency = "EUR",
                PaymentDate = DateTime.Now,
                PaymentType = PaymentType.PrePaid,
                Status = PaymentStatus.Pending
            };
        }

        [Test]
        public void ThrowsWhenNullPayment()
        {
            Assert.Throws<InvalidPaymentException>(() => { _validator.Validate(null); });
        }

        [TestCase(null, null)]
        [TestCase(0, "")]
        [TestCase(10, "")]
        [TestCase(0, "USD")]
        public void ThrowsWhenInvalidPaymentData(decimal amount, string currency)
        {
            _validPayment.Amount = amount;
            _validPayment.Currency = currency;

            Assert.Throws<InvalidPaymentException>(() => _validator.Validate(_validPayment));
        }

        [Test]
        public void DoesNotThrowWhenPaymentIsValid()
        {
            Assert.DoesNotThrow(() => _validator.Validate(_validPayment));
        }
    }
}
