namespace NS.Booking.Domain.Payment.Services
{
    using System.Collections.Generic;

    using NS.Booking.Domain.Payment.Models;

    public interface IGetExternalPaymentDataDomainService
    {
        List<string> SupportedMethods { get; }

        string Get(PrePaidPayment payment);
    }
}