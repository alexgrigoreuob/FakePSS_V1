namespace NS.Booking.Domain.Payment.Services
{
    using NS.Booking.Domain.Payment.Models;

    public interface IConfirmPaymentDomainService : IPaymentDomainServiceBase
    {
        void ConfirmPayment(Payment payment);
    }
}