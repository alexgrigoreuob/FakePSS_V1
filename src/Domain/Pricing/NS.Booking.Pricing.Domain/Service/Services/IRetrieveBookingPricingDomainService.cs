using Newshore.Core.DDD.Concepts;
using NS.Booking.Pricing.Domain.Service.Models;

namespace NS.Booking.Pricing.Domain.Service.Services
{
    public interface IRetrieveBookingPricingDomainService : IDomainService
    {
        BookingPricing Retrieve();
    }
}