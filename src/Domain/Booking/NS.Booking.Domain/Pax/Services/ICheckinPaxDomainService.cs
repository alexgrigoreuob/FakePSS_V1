namespace NS.Booking.Domain.Pax.Services
{
    using NS.Booking.Domain.Booking.Models;
    using NS.Booking.Domain.Checkin.Models.Requests;
    using System.Collections.Generic;

    using Newshore.Core.DDD.Concepts;

    public interface ICheckinPaxDomainService : IDomainService
    {
        void Checkin(List<CheckinRequest> pax, Booking booking);
    }
}
