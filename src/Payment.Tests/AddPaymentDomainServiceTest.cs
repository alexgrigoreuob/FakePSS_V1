using System;
using System.Collections.Generic;
using Moq;
using Newshore.Core.Storage.Interfaces;
using NS.Booking.Domain.Payment.Enums;
using NS.Booking.Domain.Payment.Services;
using NS.Booking.Infrastructure.Fake.Payment.Models;
using NS.Booking.Infrastructure.Fake.Payment.Services;
using NUnit.Framework;

namespace NS.Booking.Infrastructure.Fake.Payment.Tests
{
    [TestFixture]
    public class AddPaymentDomainServiceTest
    {
        private Mock<IStoreInSessionStrategy> _sessionStorageMock;
        private IAddPaymentDomainService _paymentAdder;

        [SetUp]
        public void SetUp()
        {
            _sessionStorageMock = new Mock<IStoreInSessionStrategy>(MockBehavior.Strict);
            _paymentAdder = new AddCreditCardPaymentDomainService(_sessionStorageMock.Object);
        }

        [Test]
        public void AddPaymentShouldAddPaymentListToStorage()
        {
            var currentPaymentList = new List<NS.Booking.Domain.Payment.Models.Payment>
            {
                new NS.Booking.Domain.Payment.Models.PrePaidPayment
                {
                    Status = PaymentStatus.Pending,
                    Amount = 10,
                    Currency = "EUR",
                    PaymentDate = DateTime.Now,
                    PaymentMethod = "WP",
                    PaymentType = PaymentType.CreditCard,
                    ReferenceId = "123456"
                }
            };

            _sessionStorageMock
                .Setup(x => x.Get<List<Domain.Payment.Models.Payment>>(SessionKeys.DomainPayments, true))
                .Returns(currentPaymentList);
            _sessionStorageMock.Setup(x => x.Add(SessionKeys.DomainPayments,
                It.Is<List<Domain.Payment.Models.Payment>>(y => y.Count == 2), true));

            _paymentAdder.AddPayment(new NS.Booking.Domain.Payment.Models.CreditCardPayment
            {
                Amount = 20,
                Currency = "EUR",
                PaymentDate = DateTime.Now,
                PaymentMethod = "MC",
                PaymentType = PaymentType.CreditCard,
                ReferenceId = "456789",
                CardHolder = "Pepe Juarez",
                CardNumber = "123456789",
                ExpirationMonth = 05,
                ExpirationYear = 25,
                Status = PaymentStatus.Declined
            });
        }
    }
}
