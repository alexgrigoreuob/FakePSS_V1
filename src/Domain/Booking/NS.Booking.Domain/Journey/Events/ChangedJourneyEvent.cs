﻿namespace NS.Booking.Domain.Journey.Events
{
    using Newshore.Core.EDA.Concepts;
    using NS.Booking.Domain.Journey.Models;
    using System.Collections.Generic;

    public class ChangedJourneyEvent : IDomainEvent
    {
        public List<Journey> Journeys { get; set; }
    }
}
