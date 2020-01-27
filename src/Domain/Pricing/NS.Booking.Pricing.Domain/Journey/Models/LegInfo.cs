namespace NS.Booking.Pricing.Domain.Journey.Models
{
    using Newshore.Core.DDD.Concepts;

    public class LegInfo : ValueObject
    {
        public bool IsSubjectedToGovernmentApproval { get; set; }
    }
}