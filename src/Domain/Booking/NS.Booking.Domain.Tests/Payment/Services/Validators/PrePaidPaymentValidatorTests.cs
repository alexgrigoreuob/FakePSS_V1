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
    public class PrePaidPaymentValidatorTests
    {
        private IValidator<PrePaidPayment> _validator;
        private PrePaidPayment _validPayment;

        [SetUp]
        public void Setup()
        {
            _validator = new PrePaidPaymentValidator();
            _validPayment = new PrePaidPayment()
            {
                Amount = 10,
                Currency = "EUR",
                PaymentDate = DateTime.Now,
                PaymentMethod = "VI",
                PaymentType = PaymentType.PrePaid,
                Status = PaymentStatus.Pending
            };
        }

        [Test]
        public void ThrowsWhenNullPayment()
        {
            Assert.Throws<InvalidPrePaidPaymentException>(() => { _validator.Validate(null); });
        }

        [TestCase(null)]
        [TestCase("")]
        public void ThrowsWhenInvalidPaymentData(string paymentMethod)
        {
            _validPayment.PaymentMethod = paymentMethod;

            Assert.Throws<InvalidPrePaidPaymentException>(() => _validator.Validate(_validPayment));
        }

        [Test]
        public void DoesNotThrowWhenPaymentIsValid()
        {
            Assert.DoesNotThrow(() => _validator.Validate(_validPayment));
        }
    }
}
