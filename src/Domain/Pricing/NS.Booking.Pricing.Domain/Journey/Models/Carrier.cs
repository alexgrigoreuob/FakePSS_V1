namespace NS.Booking.Pricing.Domain.Journey.Models
{
    using Newshore.Core.DDD.Concepts;

    public class Carrier : ValueObject
    {
        public string Code { get; set; }

        public string Name { get; set; }
    }
}