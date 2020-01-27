namespace NS.Booking.Domain.Fee.Services
{
    using Newshore.Core.DDD.Concepts;
    using NS.Booking.Common.Domain.PricedItem.Enums;
    public interface IFeeDomainServiceBase : IDomainService
    {
        ProductScopeType ProductScopeType { get; set; }
    }
}
