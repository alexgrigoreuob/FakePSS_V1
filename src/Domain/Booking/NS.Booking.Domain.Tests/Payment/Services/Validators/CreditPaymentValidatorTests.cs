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
    public class CreditPaymentValidatorTests
    {
        private IValidator<CreditPayment> _validator;
        private CreditPayment _validPayment;

        [SetUp]
        public void Setup()
        {
            _validator = new CreditPaymentValidator();
            _validPayment = new CreditPayment()
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
        public void ThrowsWhenNullPayment()
        {
            Assert.Throws<InvalidCreditPaymentException>(() => { _validator.Validate(null); });
        }

        [TestCase(null)]
        [TestCase(0)]
        public void ThrowsWhenInvalidPaymentData(decimal paymentCredit)
        {
            _validPayment.Credit = paymentCredit;

            Assert.Throws<InvalidCreditPaymentException>(() => _validator.Validate(_validPayment));
        }

        [Test]
        public void DoesNotThrowWhenPaymentIsValid()
        {
            Assert.DoesNotThrow(() => _validator.Validate(_validPayment));
        }
    }
}