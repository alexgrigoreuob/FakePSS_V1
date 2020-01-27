namespace NS.Booking.Domain.Booking.Models
{
    using System.Collections.Generic;

    using Newshore.Core.DDD.Concepts;
    using Newshore.Core.IoC;
    using Newshore.Core.NativeObjects.Extensions;

    using NS.Booking.Common.Domain.Common.Validators;
    using NS.Booking.Domain.Bundles.Models;
    using NS.Booking.Domain.Contact.Models;
    using NS.Booking.Domain.Journey.Models;
    using NS.Booking.Domain.Pax.Models;
    using NS.Booking.Domain.Payment.Models;
    using NS.Booking.Domain.Service.Models;

    public class Booking : AggregateRoot
    {
        private readonly List<IValidator<Booking>> validators;

        public Booking()
        {
            this.validators = IoCContainer.Instance.ResolveAll<IValidator<Booking>>();
            this.BookingInfo = new BookingInfo(this);
            this.Journeys = new List<Journey>();
            this.Pax = new List<Pax>();
            this.Contacts = new List<Contact>();
            this.Payments = new List<Payment>();
            this.Pricing = new BookingPricing(this);
            this.Services = new List<Service>();
            this.Bundles = new List<Bundle>();
            this.Etickets = new List<Eticket>();
        }

        public override string Id
        {
            get
            {
                var referenceId = string.IsNullOrEmpty(this.BookingInfo.ReferenceId) ? string.Empty : this.BookingInfo.ReferenceId.EncodeHexadecimal();

                if (string.IsNullOrEmpty(this.BookingInfo.RecordLocator))
                {
                    return string.Empty;
                }

                return $"{this.BookingInfo.RecordLocator}~{this.BookingInfo.CreatedDate:yyyy-MM-dd}~{referenceId}".EncodeHexadecimal();
            }
        }

        public List<Journey> Journeys { get; set; }

        public List<Pax> Pax { get; set; }

        public List<Contact> Contacts { get; set; }

        public List<Payment> Payments { get; set; }

        public List<Service> Services { get; set; }

        public BookingInfo BookingInfo { get; set; }

        public BookingPricing Pricing { get; set; }

        public List<Bundle> Bundles { get; set; }

        public List<Eticket> Etickets { get; set; }

        public void Validate()
        {
            this.validators.ForEach(x => x.Validate(this));
        }
    }
}