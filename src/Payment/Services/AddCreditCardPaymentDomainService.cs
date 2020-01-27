using System;
using System.Collections.Generic;
using Newshore.Core.Storage.Interfaces;
using NS.Booking.Domain.Payment.Enums;
using NS.Booking.Domain.Payment.Exceptions;
using NS.Booking.Domain.Payment.Models;
using NS.Booking.Domain.Payment.Services;
using NS.Booking.Infrastructure.Fake.Payment.Models;

namespace NS.Booking.Infrastructure.Fake.Payment.Services
{
    public class AddCreditCardPaymentDomainService : IAddPaymentDomainService
    {
        private readonly IStoreInSessionStrategy _sessionStorage;
        public List<string> SupportedMethods { get; }
        public PaymentType SupportedType { get; }
        private readonly Random _random;

        public AddCreditCardPaymentDomainService(IStoreInSessionStrategy sessionStorage)
        {
            _sessionStorage = sessionStorage;
            SupportedMethods = new List<string> { "VI", "MC" };
            SupportedType = PaymentType.CreditCard;
            _random = new Random();
        }

        public void AddPayment(Domain.Payment.Models.Payment payment)
        {
            //Verify payment type and method are supported.
            if (payment.PaymentType != SupportedType)
            {
                throw new InvalidPaymentException("Payment type not supported by current payment service.");
            }
            if (!SupportedMethods.Contains(((CreditCardPayment)payment).PaymentMethod))
            {
                throw new InvalidPaymentException("Payment method not supported by current payment service.");
            }

            var paymentList =
                _sessionStorage.Get<List<Domain.Payment.Models.Payment>>(SessionKeys.DomainPayments) ??
                new List<Domain.Payment.Models.Payment>();

            //Add Reference Id to generate Payment Id.
            payment.ReferenceId = "123456";

            //Generate random status.
            payment.Status = _random.Next(100) <= 80
                ? PaymentStatus.Approved
                : _random.Next(100) <= 50
                    ? PaymentStatus.Pending
                    : PaymentStatus.Declined;

            paymentList.Add(payment);

            _sessionStorage.Add(SessionKeys.DomainPayments, paymentList);
        }
    }
}
