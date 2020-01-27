namespace NS.Booking.Domain.Payment.Services
{
    using Newshore.Core.DDD.Concepts;
    using NS.Booking.Domain.Payment.Models;
    using System.Collections.Generic;

    public interface IGetPaymentDomainService : IDomainService
    {
        List<Payment> GetPayments();
    }
}
