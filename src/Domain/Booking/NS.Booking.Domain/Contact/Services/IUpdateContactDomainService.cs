namespace NS.Booking.Domain.Contact.Services
{
    using NS.Booking.Domain.Contact.Models.Requests;
    using System.Collections.Generic;

    using Newshore.Core.DDD.Concepts;

    public interface IUpdateContactDomainService : IDomainService
    {
        void UpdateContacts(List<UpdateContactRequest> contacts);
    }
}
