namespace NS.Booking.Domain.Queue.Events
{
    using Newshore.Core.EDA.Concepts;

    public class AddedQueueEvent : IDomainEvent
    {
        public Booking.Models.Queue Queue { get; set; }
    }
}
