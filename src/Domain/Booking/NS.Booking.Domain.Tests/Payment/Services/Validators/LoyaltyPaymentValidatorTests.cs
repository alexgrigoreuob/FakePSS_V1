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
    public class LoyaltyPaymentValidatorTests
    {
        private IValidator<LoyaltyPayment> _validator;
        private LoyaltyPayment _validPayment;

        [SetUp]
        public void Setup()
        {
            _validator = new LoyaltyPaymentValidator();
            _validPayment = new LoyaltyPayment()
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
        public void ThrowsWhenNullPayment()
        {
            Assert.Throws<InvalidLoyaltyPaymentException>(() => { _validator.Validate(null); });
        }

        [TestCase(null)]
        [TestCase(0)]
        public void ThrowsWhenInvalidPaymentData(decimal paymentPoints)
        {
            _validPayment.Points = paymentPoints;

            Assert.Throws<InvalidLoyaltyPaymentException>(() => _validator.Validate(_validPayment));
        }

        [Test]
        public void DoesNotThrowWhenPaymentIsValid()
        {
            Assert.DoesNotThrow(() => _validator.Validate(_validPayment));
        }
    }
}