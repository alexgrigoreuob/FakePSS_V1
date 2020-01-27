namespace NS.Booking.Domain.Payment.Services
{
    using NS.Booking.Domain.Payment.Models;

    public interface IAddPaymentDomainService : IPaymentDomainServiceBase
    {
        void AddPayment(Payment payment);
    }
}