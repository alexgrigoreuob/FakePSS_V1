namespace NS.Booking.Infrastructure.Fake.Booking.Services
{
    using Newshore.Core.Storage.Interfaces;
    using NS.Booking.Common.Domain.Person.Enums;
    using NS.Booking.Domain.Booking.Exceptions;
    using NS.Booking.Domain.Booking.Models;
    using NS.Booking.Domain.Booking.Models.Requests;
    using NS.Booking.Domain.Booking.Services;
    using NS.Core.Storage.Cache.Distributed;
    using System.Linq;

    public class RetrieveBookingDomainService : IRetrieveBookingDomainService
    {
        private readonly IDistributedCacheStrategy _distributedCache;
        private readonly IStoreInSessionStrategy _sessionStorage;

        public RetrieveBookingDomainService(IDistributedCacheStrategy distributedCache,
            IStoreInSessionStrategy sessionStorage)
        {
            this._distributedCache = distributedCache;
            this._sessionStorage = sessionStorage;
        }

        public Booking Retrieve(RetrieveBookingRequest request)
        {
            var booking = this._distributedCache.Get<Booking>($"ConfirmedBooking_{request.RecordLocator}");
            if (booking == null || 
                (booking.Contacts.All(contact =>
                        !contact.Channels.Any(channel => 
                            channel.Type == ChannelType.Email && channel.Info == request.ContactEmail)) &&
                booking.Pax.All(pax =>
                        pax.Name.Last != request.PaxSurname)))
            {
                throw new BookingNotFoundException();
            }

            this._sessionStorage.Add("DomainBooking", booking);
            this._sessionStorage.Add("DomainPayments", booking.Payments);
            this._sessionStorage.Add("DomainContacts", booking.Contacts);
            this._sessionStorage.Add("DomainServices", booking.Services);

            return booking;
        }
    }
}