namespace NS.Booking.Domain.Tests.Payment.Models
{
    using NS.Booking.Domain.Payment.Enums;
    using NS.Booking.Domain.Payment.Exceptions;
    using NS.Booking.Domain.Payment.Models;
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class PaymentTests
    {
        private Payment _validPayment;
        private Payment _invalidPayment;

        [SetUp]
        public void Setup()
        {
            _invalidPayment = new Payment();
            _validPayment = new Payment
            {
                Amount = 10,
                Currency = "EUR",
                PaymentDate = DateTime.Now,
                PaymentType = PaymentType.PrePaid,
                Status = PaymentStatus.Pending,
                ReferenceId = "1234563789"
            };
        }

        [Test]
        public void ShouldReturnNewInvalidPaymentException()
        {
            Assert.Throws<InvalidPaymentException>(() => { _invalidPayment.Validate(); });
        }

        [Test]
        public void ShouldReturnNewValidPayment()
        {
            _validPayment.Validate();
        }

        [Test]
        public void ShouldReturnValidPaymentId()
        {
            Assert.IsNotNull(_validPayment.Id);
        }

        [Test]
        public void ShouldReturnNullPaymentId()
        {
            Assert.IsNull(_invalidPayment.Id);
        }
    }
}
