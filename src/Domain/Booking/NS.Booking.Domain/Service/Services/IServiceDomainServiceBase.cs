namespace NS.Booking.Domain.Service.Services
{
	using Newshore.Core.DDD.Concepts;
	using NS.Booking.Common.Domain.PricedItem.Enums;
	using NS.Booking.Common.Domain.Service.Enums;
	using System.Collections.Generic;

	public interface IServiceDomainServiceBase : IDomainService
    {
        List<ServiceType> Types { get; set; }

        ProductScopeType ProductScopeType { get; set; }
    }
}
