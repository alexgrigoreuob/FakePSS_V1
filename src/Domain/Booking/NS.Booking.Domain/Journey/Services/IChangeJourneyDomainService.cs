namespace NS.Booking.Domain.Journey.Services
{
    using NS.Booking.Domain.Journey.Models.Requests;
    using System.Collections.Generic;

    using Newshore.Core.DDD.Concepts;

    public interface IChangeJourneyDomainService : IDomainService
    {
        void ChangeJourneys(List<ChangeJourneyRequest> request);
    }
}
