namespace NS.Booking.Domain.Tests.Payment.Models
{
    using NS.Booking.Domain.Payment.Enums;
    using NS.Booking.Domain.Payment.Exceptions;
    using NS.Booking.Domain.Payment.Models;
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class MobilePaymentTests
    {
        private MobilePayment _validMobilePayment;
        private MobilePayment _invalidMobilePayment;

        [SetUp]
        public void SetUp()
        {
            _invalidMobilePayment = new MobilePayment();
            _validMobilePayment = new MobilePayment
            {
                Amount = 10,
                Currency = "EUR",
                PaymentDate = DateTime.Now,
                PaymentType = PaymentType.Mobile,
                Status = PaymentStatus.Pending,
                Phone = "123456789",
                Country = "ES",
                Operator = "Newshore",
                Prefix = "001"
            };
        }

        [Test]
        public void ShouldReturnInvalidPaymentException()
        {
            Assert.Throws<InvalidPaymentException>(() => _invalidMobilePayment.Validate());
        }

        [Test]
        public void ShouldReturnInvalidMobilePaymentException()
        {
            _validMobilePayment.Phone = null;
            Assert.Throws<InvalidMobilePaymentException>(() => _validMobilePayment.Validate());
        }

        [Test]
        public void ShouldReturnNewValidPayment()
        {
            _validMobilePayment.Validate();
        }
    }
}
