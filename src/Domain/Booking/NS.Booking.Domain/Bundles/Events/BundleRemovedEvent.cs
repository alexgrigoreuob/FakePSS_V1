namespace NS.Booking.Domain.Bundles.Events
{
    using Newshore.Core.EDA.Concepts;
    using NS.Booking.Domain.Bundles.Models;

    public class BundleRemovedEvent : IDomainEvent
    {
        public Bundle Bundle { get; set; }
    }
}
