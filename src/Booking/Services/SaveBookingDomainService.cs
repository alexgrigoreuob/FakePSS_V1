namespace NS.Booking.Infrastructure.Fake.Booking.Services
{
    using Newshore.Core.Storage.Interfaces;
    using NS.Booking.Domain.Booking.Models;
    using NS.Booking.Domain.Booking.Services;
    using NS.Core.Storage.Cache.Distributed;
    using System;
    using System.Threading;

    public class SaveBookingDomainService : ISaveBookingDomainService
    {
        private readonly IDistributedCacheStrategy _distributedCache;
        private readonly IStoreInSessionStrategy _sessionStorage;

        public SaveBookingDomainService(IDistributedCacheStrategy distributedCache,
            IStoreInSessionStrategy sessionStorage)
        {
            this._distributedCache = distributedCache;
            this._sessionStorage = sessionStorage;
        }

        public void Save(Booking booking)
        {
            if (string.IsNullOrEmpty(booking.BookingInfo.RecordLocator))
            {
                booking.BookingInfo.RecordLocator = this.GenerateRandom().ToString("D6");
                booking.BookingInfo.CreatedDate = DateTime.UtcNow;
            }

            this._sessionStorage.Add("DomainBooking", booking);

            // Save bookings in cache for 5 days
            this._distributedCache.Add($"ConfirmedBooking_{booking.BookingInfo.RecordLocator}", booking, 7200);
        }

        private int GenerateRandom()
        {
            Thread.Sleep(10);
            return new Random().Next(0, 999999);
        }
    }
}