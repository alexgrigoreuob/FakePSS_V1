namespace NS.Booking.Pricing.Domain.Journey.Services.Validators
{
    using NS.Booking.Common.Domain.Common.Validators;
    using NS.Booking.Pricing.Domain.Journey.Enums;
    using NS.Booking.Pricing.Domain.Journey.Exceptions;
    using NS.Booking.Pricing.Domain.Journey.Models.Requests;
    using System;
    using System.Globalization;
    using System.Linq;
    using System.Text.RegularExpressions;

    public class JourneyPriceRequestValidator : IValidator<JourneyPriceRequest>
    {
        public void Validate(JourneyPriceRequest request)
        {
            // TODO: Allow * for cache
            var stationPattern = new Regex("^[A-Z]{3}$");
            var openStationPattern = new Regex("^[*]{1}$");
            if (string.IsNullOrEmpty(request.Origin) || (!stationPattern.IsMatch(request.Origin) && !openStationPattern.IsMatch(request.Origin))
                                                     || string.IsNullOrEmpty(request.Destination) ||
                                                     (!stationPattern.IsMatch(request.Destination) && !openStationPattern.IsMatch(request.Destination)))
            {
                throw new InvalidPricingRequestException();
            }

            if (request.Details == null || !request.Details.Any() || request.Details.Any(detail => detail.Key == AvailabilityRequestType.Default))
            {
                throw new InvalidPricingRequestException();
            }

            // TODO: FIX
            request.Details.Keys.ToList().ForEach(
                key =>
                    {
                        var value = request.Details[key];

                        foreach (DateRange dateRange in value)
                        {
                            var success = DateTime.TryParseExact(dateRange.Begin, "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.AssumeUniversal, out var beginDate);
                            success &= DateTime.TryParseExact(dateRange.End, "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.AssumeUniversal, out var endDate);

                            if (!success || beginDate > endDate)
                            {
                                throw new InvalidPricingRequestException();
                            }
                        }
                    });
                    
            // TODO: Extra validation to check value matches config file with allowed values?
            var paxPattern = new Regex("^[A-Z]{3}$");
            if (request.Pax.Any(pax => pax.Value < 0 || string.IsNullOrEmpty(pax.Key) || !paxPattern.IsMatch(pax.Key)))
            {
                throw new InvalidPricingRequestException();
            }

            var currencyPattern = new Regex("^[A-Z]{3}$");
            if (!string.IsNullOrEmpty(request.Currency) && !currencyPattern.IsMatch(request.Currency))
            {
                throw new InvalidPricingRequestException();
            }

            var countryPattern = new Regex("^[A-Z]{2}$");
            if (request.PointOfSale != null && (string.IsNullOrEmpty(request.PointOfSale.Country) || !countryPattern.IsMatch(request.PointOfSale.Country)))
            {
                throw new InvalidPricingRequestException();
            }
        }
    }
}