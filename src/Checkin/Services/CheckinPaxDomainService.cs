namespace NS.Booking.Infrastructure.Fake.Checkin.Services
{
    using Newshore.Core.Storage.Interfaces;
    using NS.Booking.Domain.Booking.Models;
    using NS.Booking.Domain.Checkin.Models.Requests;
    using NS.Booking.Domain.Pax.Enums;
    using NS.Booking.Domain.Pax.Services;
    using NS.Core.Storage.Cache.Distributed;
    using System;
    using System.Collections.Generic;

    public class CheckinPaxDomainService : ICheckinPaxDomainService
    {
        private readonly IStoreInSessionStrategy _sessionStorage;
        private readonly IDistributedCacheStrategy _distributedCache;
        private readonly Random _random;

        public CheckinPaxDomainService(IStoreInSessionStrategy sessionStorage,
            IDistributedCacheStrategy distributedCache)
        {
            this._sessionStorage = sessionStorage;
            this._distributedCache = distributedCache;
            this._random = new Random();
        }

        public void Checkin(List<CheckinRequest> pax, Booking booking)
        {
            pax.ForEach(x =>
            {
                var bussySeats = this._distributedCache.Get<List<string>>($"SeatsPer_{x.SegmentId}");
                if (bussySeats == null)
                {
                    bussySeats = new List<string> { "00" };
                }
                x.Pax.ForEach(y =>
                {
                    var segmentInfo = booking.Pax.Find(z => z.Id.Equals(y))
                        .SegmentsInfo.Find(z => z.SegmentId == x.SegmentId);
                    if (segmentInfo.Status == PaxStatus.Default)
                    {
                        segmentInfo.Status = PaxStatus.CheckedIn;
                    }
                    if (string.IsNullOrEmpty(segmentInfo.Seat))
                    {
                        var seat = "00";
                        while (bussySeats.Contains(seat))
                        {
                            seat = AutoAssignSeat();
                        }
                        bussySeats.Add(seat);
                        segmentInfo.Seat = seat;
                    }
                });
                this._distributedCache.Add($"SeatsPer_{x.SegmentId}", bussySeats, 7200);
            });
            this._sessionStorage.Add("DomainBooking", booking);
        }

        private string AutoAssignSeat()
        {
            var row = this._random.Next(1, 26);
            var letter = (char)('A' + this._random.Next(0, 6));
            return $"{row}{letter}";
        }
    }
}
