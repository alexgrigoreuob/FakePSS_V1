namespace NS.Booking.Domain.Pax.Events
{
    using Newshore.Core.EDA.Concepts;
    using NS.Booking.Domain.Pax.Models;
    using System.Collections.Generic;

    public class UpdatedPaxEvent : IDomainEvent
    {
        public List<Pax> Pax { get; set; }
    }
}
