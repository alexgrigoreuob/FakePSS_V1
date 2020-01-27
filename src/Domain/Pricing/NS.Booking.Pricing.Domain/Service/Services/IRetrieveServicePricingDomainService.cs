namespace NS.Booking.Pricing.Domain.Service.Services
{
    using Newshore.Core.DDD.Concepts;
    using NS.Booking.Pricing.Domain.Service.Models;
    using NS.Booking.Pricing.Domain.Service.Models.Requests;
    using System.Collections.Generic;
    using NS.Booking.Common.Domain.Service.Enums;

    public interface IRetrieveServicePricingDomainService : IDomainService
    {
        List<ServiceType> SupportedTypes { get; }

        List<Service> Retrieve(ServicePriceRequest request);
    }
}