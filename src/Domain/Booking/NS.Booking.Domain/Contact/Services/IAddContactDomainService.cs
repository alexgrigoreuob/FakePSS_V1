namespace NS.Booking.Domain.Contact.Services
{
    using System.Collections.Generic;

    using Newshore.Core.DDD.Concepts;

    using NS.Booking.Domain.Contact.Models;

    public interface IAddContactDomainService : IDomainService
    {
        void AddContacts(List<Contact> contacts);
    }
}
