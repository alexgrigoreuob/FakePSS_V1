namespace NS.Booking.Domain.Pax.Events
{
    using NS.Booking.Domain.Checkin.Models.Requests;
    using System.Collections.Generic;

    using Newshore.Core.EDA.Concepts;

    public class CheckedInPaxEvent : IDomainEvent
    {
        public List<CheckinRequest> SegmentsPax { get; set; }
    }
}
