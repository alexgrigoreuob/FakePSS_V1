namespace NS.Booking.Domain.Bundles.Services
{
    using Newshore.Core.DDD.Concepts;
    using NS.Booking.Common.Domain.PricedItem.Enums;

    public interface IBundleDomainServiceBase : IDomainService
    {
        ProductScopeType Scope { get; }
    }
}
