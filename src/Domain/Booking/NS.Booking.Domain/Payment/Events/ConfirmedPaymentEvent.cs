namespace NS.Booking.Domain.Payment.Events
{
    using Newshore.Core.EDA.Concepts;
    using NS.Booking.Domain.Payment.Models;

    public class ConfirmedPaymentEvent : IDomainEvent
    {
        public Payment Payment { get; set; }
    }
}
