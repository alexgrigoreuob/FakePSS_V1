namespace NS.Booking.Domain.Pax.Services
{
    using NS.Booking.Domain.Booking.Models;
    using NS.Booking.Domain.Checkin.Models.Responses;
    using System.Collections.Generic;

    using Newshore.Core.DDD.Concepts;

    public interface IGetPaxCheckinStatusDomainService : IDomainService
    {
        List<SegmentCheckinStatusResponse> Status(Booking booking);
    }
}
