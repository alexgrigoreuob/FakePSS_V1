namespace NS.Booking.Domain.Offer.Models
{
    using NS.Booking.Common.Domain.Charge.Models;
    using NS.Booking.Common.Domain.Service.Enums;
    using System.Collections.Generic;

    public class Service
    {
        public ServiceType Type { get; set; }

        public string Code { get; set; }

        public List<Charge> Charges { get; set; }
    }
}