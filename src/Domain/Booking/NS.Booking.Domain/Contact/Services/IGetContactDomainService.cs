namespace NS.Booking.Domain.Contact.Services
{
    using System.Collections.Generic;

    using Newshore.Core.DDD.Concepts;

    using NS.Booking.Domain.Contact.Models;

    public interface IGetContactDomainService : IDomainService
    {
        List<Contact> GetContacts();
    }
}
