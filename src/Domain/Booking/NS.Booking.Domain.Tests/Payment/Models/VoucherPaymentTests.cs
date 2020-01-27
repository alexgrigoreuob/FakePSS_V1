namespace NS.Booking.Domain.Tests.Payment.Models
{
    using NS.Booking.Domain.Payment.Enums;
    using NS.Booking.Domain.Payment.Exceptions;
    using NS.Booking.Domain.Payment.Models;
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class VoucherPaymentTests
    {
        private VoucherPayment _validVoucherPayment;
        private VoucherPayment _invalidVoucherPayment;

        [SetUp]
        public void SetUp()
        {
            _invalidVoucherPayment = new VoucherPayment();
            _validVoucherPayment = new VoucherPayment
            {
                Amount = 10,
                Currency = "EUR",
                PaymentDate = DateTime.Now,
                PaymentType = PaymentType.Voucher,
                Status = PaymentStatus.Pending,
                VoucherId = "123456",
                AvailableAmount = 0
            };
        }

        [Test]
        public void ShouldReturnInvalidPaymentException()
        {
            Assert.Throws<InvalidPaymentException>(() => _invalidVoucherPayment.Validate());
        }

        [Test]
        public void ShouldReturnInvalidVoucherPaymentException()
        {
            _validVoucherPayment.VoucherId = null;
            Assert.Throws<InvalidVoucherPaymentException>(() => _validVoucherPayment.Validate());
        }

        [Test]
        public void ShouldReturnNewValidPayment()
        {
            _validVoucherPayment.Validate();
        }
    }
}
