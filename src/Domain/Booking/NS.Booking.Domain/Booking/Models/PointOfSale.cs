namespace NS.Booking.Domain.Booking.Models
{
    using Newshore.Core.DDD.Concepts;

    public class PointOfSale : ValueObject
    {
        public Agent Agent { get; set; }

        public Organization Organization { get; set; }
    }
}