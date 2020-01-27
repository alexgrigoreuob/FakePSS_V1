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
    public class VoucherPaymentValidatorTests
    {
        private IValidator<VoucherPayment> _validator;
        private VoucherPayment _validPayment;

        [SetUp]
        public void Setup()
        {
            _validator = new VoucherPaymentValidator();
            _validPayment = new VoucherPayment()
            {
                Amount = 10,
                Currency = "EUR",
                PaymentDate = DateTime.Now,
                PaymentType = PaymentType.Voucher,
                Status = PaymentStatus.Pending,
                VoucherId = "123456"
            };
        }

        [Test]
        public void ThrowsWhenNullPayment()
        {
            Assert.Throws<InvalidVoucherPaymentException>(() => { _validator.Validate(null); });
        }

        [TestCase(null)]
        [TestCase("")]
        public void ThrowsWhenInvalidPaymentData(string voucherId)
        {
            _validPayment.VoucherId = voucherId;

            Assert.Throws<InvalidVoucherPaymentException>(() => _validator.Validate(_validPayment));
        }

        [Test]
        public void DoesNotThrowWhenPaymentIsValid()
        {
            Assert.DoesNotThrow(() => _validator.Validate(_validPayment));
        }
    }
}