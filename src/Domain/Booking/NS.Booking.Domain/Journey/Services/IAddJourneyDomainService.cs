namespace NS.Booking.Domain.Journey.Services
{
    using NS.Booking.Domain.Journey.Models.Requests;
    using System.Collections.Generic;

    using Newshore.Core.DDD.Concepts;

    public interface IAddJourneyDomainService : IDomainService
    {
        void AddJourneys(List<JourneyRequest> journeys);
    }
}
