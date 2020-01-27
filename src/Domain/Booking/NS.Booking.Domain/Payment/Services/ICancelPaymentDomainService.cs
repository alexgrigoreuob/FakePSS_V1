namespace NS.Booking.Domain.Payment.Services
{
    using NS.Booking.Domain.Payment.Models;

    public interface ICancelPaymentDomainService : IPaymentDomainServiceBase
    {
        void CancelPayment(Payment payment);
    }
}