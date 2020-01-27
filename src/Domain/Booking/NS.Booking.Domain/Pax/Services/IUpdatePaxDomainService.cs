namespace NS.Booking.Domain.Pax.Services
{
    using NS.Booking.Domain.Pax.Models.Requests;
    using System.Collections.Generic;

    using Newshore.Core.DDD.Concepts;

    public interface IUpdatePaxDomainService : IDomainService
    {
        void UpdatePax(List<UpdatePaxRequest> pax);
    }
}
