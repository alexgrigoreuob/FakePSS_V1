namespace NS.Booking.Domain.Booking.Models
{
    using System;

    using Newshore.Core.DDD.Concepts;

    public class Queue : ValueObject
    {
        public string Code { get; set; }

        public DateTime QueuedDate { get; set; }
    }
}