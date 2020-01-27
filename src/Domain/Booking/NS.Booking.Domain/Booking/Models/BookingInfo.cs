namespace NS.Booking.Domain.Booking.Models
{
    using Newshore.Core.DDD.Concepts;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;
    using NS.Booking.Domain.Booking.Enums;
    using System;
    using System.Collections.Generic;

    public class BookingInfo : ValueObject
    {
        private readonly Booking booking;

        public BookingInfo(Booking booking)
        {
            this.booking = booking;
            this.Comments = new List<Comment>();
            this.Queues = new List<Queue>();
        }

        public string ReferenceId { get; set; }

        public string RecordLocator { get; set; }

        public List<Comment> Comments { get; set; }

        public List<Queue> Queues { get; set; }

        [JsonConverter(typeof(StringEnumConverter))]
        public BookingStatus Status
        {
            get
            {
                if (string.IsNullOrEmpty(this.RecordLocator))
                {
                    return BookingStatus.Creating;
                }

                if (this.booking.Pricing.IsBalanced || this.booking.Pricing.BalanceDue < decimal.Zero)
                {
                    return BookingStatus.Confirmed;
                }

                return BookingStatus.Hold;
            }
        }

        public DateTime CreatedDate { get; set; }

        public PointOfSale PointOfSale { get; set; }
    }
}