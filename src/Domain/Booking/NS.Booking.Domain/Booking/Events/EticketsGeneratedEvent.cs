namespace NS.Booking.Domain.Booking.Events
{
    using Newshore.Core.EDA.Concepts;

    using NS.Booking.Domain.Booking.Models;

    public class EticketsGeneratedEvent : IDomainEvent
    {
        public Booking Booking { get; set; }
    }
}