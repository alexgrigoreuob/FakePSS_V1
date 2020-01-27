namespace NS.Booking.Pricing.Domain.Journey.Services
{
    using NS.Booking.Pricing.Domain.Journey.Enums;
    using NS.Booking.Pricing.Domain.Journey.Models.Requests;
    using NS.Booking.Pricing.Domain.Journey.Models.Responses;
    using System.Collections.Generic;

    using Newshore.Core.DDD.Concepts;

    public interface IRetrieveJourneysPricingDomainService : IDomainService
    {
        List<AvailabilityRequestType> AllowedRequestTypes { get; }

        AvailabilityRequestMethod AllowedRequestMethod { get; }

        List<JourneyPriceResponse> Retrieve(List<JourneyPriceRequest> requests);
    }
}