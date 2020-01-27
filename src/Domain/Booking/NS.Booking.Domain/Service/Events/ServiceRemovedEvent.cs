namespace NS.Booking.Domain.Service.Events
{
	using Newshore.Core.EDA.Concepts;
	using NS.Booking.Domain.Service.Models;
    public class ServiceRemovedEvent : IDomainEvent
    {
        public Service Service { get; set; }
    }
}
