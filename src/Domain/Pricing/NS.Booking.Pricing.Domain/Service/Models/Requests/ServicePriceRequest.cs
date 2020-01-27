namespace NS.Booking.Pricing.Domain.Service.Models.Requests
{
    using System.Collections.Generic;

    using NS.Booking.Common.Domain.Service.Enums;

    public class ServicePriceRequest
    {
        public BookingPricing Booking { get; set; }

        public List<ServiceType> ServiceTypes { get; set; }
    }
}
