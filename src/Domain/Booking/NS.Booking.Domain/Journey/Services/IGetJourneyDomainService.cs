namespace NS.Booking.Domain.Journey.Services
{
    using NS.Booking.Domain.Journey.Models;
    using System.Collections.Generic;

    using Newshore.Core.DDD.Concepts;

    public interface IGetJourneyDomainService : IDomainService
    {
        List<Journey> GetJourneys();
    }
}
