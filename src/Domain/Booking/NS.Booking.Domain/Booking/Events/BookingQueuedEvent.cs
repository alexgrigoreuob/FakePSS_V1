namespace NS.Booking.Domain.Booking.Events
{
    using Newshore.Core.EDA.Concepts;

    using NS.Booking.Domain.Booking.Models;

    public class BookingQueuedEvent : IDomainEvent
    {
        public string BookingId { get; set; }

        public Queue Queue { get; set; }
    }
}