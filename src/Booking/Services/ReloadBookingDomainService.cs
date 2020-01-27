namespace NS.Booking.Infrastructure.Fake.Booking.Services
{
    using Newshore.Core.Storage.Interfaces;
    using NS.Booking.Domain.Booking.Exceptions;
    using NS.Booking.Domain.Booking.Models;
    using NS.Booking.Domain.Booking.Services;
    using NS.Core.Storage.Cache.Distributed;

    public class ReloadBookingDomainService : IReloadBookingDomainService
    {
        private readonly IDistributedCacheStrategy _distributedCache;
        private readonly IStoreInSessionStrategy _sessionStorage;

        public ReloadBookingDomainService(IDistributedCacheStrategy distributedCache,
            IStoreInSessionStrategy sessionStorage)
        {
            this._distributedCache = distributedCache;
            this._sessionStorage = sessionStorage;
        }

        public void Reload()
        {
            var currentBooking = this._sessionStorage.Get<Booking>("DomainBooking");
            if (currentBooking == null)
            {
                throw new BookingNotFoundException();
            }

            var booking = this._distributedCache.Get<Booking>(
                $"ConfirmedBooking_{currentBooking.BookingInfo.RecordLocator}");

            if (booking == null)
            {
                throw new BookingNotFoundException();
            }

            this._sessionStorage.Add("DomainBooking", booking);
            this._sessionStorage.Add("DomainPayments", booking.Payments);
            this._sessionStorage.Add("DomainContacts", booking.Contacts);
            this._sessionStorage.Add("DomainServices", booking.Services);
        }
    }
}