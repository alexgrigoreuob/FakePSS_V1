namespace NS.Booking.Domain.Contact.Events
{
    using System.Collections.Generic;

    using Newshore.Core.EDA.Concepts;

    using NS.Booking.Domain.Contact.Models;

    public class UpdatedContactsEvent : IDomainEvent
    {
        public List<Contact> Contacts { get; set; }
    }
}
