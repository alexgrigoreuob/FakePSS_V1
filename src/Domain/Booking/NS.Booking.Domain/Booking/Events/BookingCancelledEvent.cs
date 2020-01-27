namespace NS.Booking.Domain.Booking.Events
{
    using Newshore.Core.EDA.Concepts;

    public class BookingCancelledEvent : IDomainEvent
    {
        public string BookingId { get; set; }
    }
}