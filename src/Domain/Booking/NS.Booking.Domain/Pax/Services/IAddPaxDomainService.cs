namespace NS.Booking.Domain.Pax.Services
{
    using NS.Booking.Domain.Pax.Models;
    using System.Collections.Generic;

    using Newshore.Core.DDD.Concepts;

    public interface IAddPaxDomainService : IDomainService
    {
        void AddPax(List<Pax> pax);
    }
}
