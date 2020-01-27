namespace NS.Booking.Domain.Tests.Payment.Models
{
    using NS.Booking.Domain.Payment.Enums;
    using NS.Booking.Domain.Payment.Exceptions;
    using NS.Booking.Domain.Payment.Models;
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class PrePaidPaymentTests
    {
        private PrePaidPayment _validPrePaidPayment;
        private PrePaidPayment _invalidPrePaidPayment;

        [SetUp]
        public void SetUp()
        {
            _invalidPrePaidPayment = new PrePaidPayment();
            _validPrePaidPayment = new PrePaidPayment
            {
                Amount = 10,
                Currency = "EUR",
                PaymentDate = DateTime.Now,
                PaymentType = PaymentType.PrePaid,
                Status = PaymentStatus.Pending,
                PaymentMethod = "WP"
            };
        }

        [Test]
        public void ShouldReturnInvalidPaymentException()
        {
            Assert.Throws<InvalidPaymentException>(() => _invalidPrePaidPayment.Validate());
        }

        [Test]
        public void ShouldReturnInvalidPrePaidPaymentException()
        {
            _validPrePaidPayment.PaymentMethod = null;
            Assert.Throws<InvalidPrePaidPaymentException>(() => _validPrePaidPayment.Validate());
        }

        [Test]
        public void ShouldReturnNewValidPayment()
        {
            _validPrePaidPayment.Validate();
        }
    }
}
