namespace NS.Booking.Pricing.Domain.Service.Services.Validators
{
    using NS.Booking.Common.Domain.Common.Validators;
    using NS.Booking.Pricing.Domain.Service.Exceptions;
    using NS.Booking.Pricing.Domain.Service.Models.Requests;
    using System.Linq;

    public class ServicePriceRequestValidator : IValidator<ServicePriceRequest>
    {
        public void Validate(ServicePriceRequest request)
        {
            if (request.Booking?.Journeys == null || !request.Booking.Journeys.Any() || string.IsNullOrEmpty(request.Booking?.Currency))
            {
                throw new InvalidServicePricingRequestException();
            }
        }
    }
}
