namespace NS.Booking.Domain.Payment.Services
{
    using Newshore.Core.DDD.Concepts;
    using NS.Booking.Domain.Payment.Models;
    using System.Collections.Generic;

    public interface IAvailablePaymentMethodsDomainService : IDomainService
    {
        List<PaymentMethod> GetAvailablePaymentMethods();
    }
}