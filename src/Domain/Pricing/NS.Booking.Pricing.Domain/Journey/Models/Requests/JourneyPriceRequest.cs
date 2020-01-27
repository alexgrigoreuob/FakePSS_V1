namespace NS.Booking.Pricing.Domain.Journey.Models.Requests
{
    using Newshore.Core.IoC;
    using NS.Booking.Common.Domain.Common.Validators;
    using NS.Booking.Pricing.Domain.Journey.Enums;
    using System.Collections.Generic;

    public class JourneyPriceRequest
    {
        private readonly List<IValidator<JourneyPriceRequest>> _validators;

        public JourneyPriceRequest()
        {
            _validators = IoCContainer.Instance.ResolveAll<IValidator<JourneyPriceRequest>>();
        }

        public string Id { get; set; }

        public string Origin { get; set; }

        public string Destination { get; set; }

        public string Currency { get; set; }

        public string PromoCode { get; set; }

        public PointOfSale PointOfSale { get; set; }

        public Dictionary<AvailabilityRequestType, List<DateRange>> Details { get; set; }

        public Dictionary<string, int> Pax { get; set; }

        // TODO: Future feature to be able to filter by custom filter implementations
        // FilterType enum must be covered by an specific filtering strategy
        // Filters can be applied before or after domain service processing
        // Example: Show journeys from specific carrier
        // Example: Show journeys with 1 stop at most
        // Example: Show journeys where price is between specific ranges
        public Dictionary<FilterType, List<string>> Filters { get; set; }

        public virtual void Validate()
        {
            _validators.ForEach(x => x.Validate(this));
        }
    }
}