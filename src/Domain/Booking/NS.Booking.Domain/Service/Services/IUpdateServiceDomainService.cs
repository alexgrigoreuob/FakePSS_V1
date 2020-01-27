namespace NS.Booking.Domain.Service.Services
{
	using NS.Booking.Domain.Service.Models.Requests;
	using NS.Booking.Domain.Service.Models;
    using Newshore.Core.DDD.Concepts;

    public interface IUpdateServiceDomainService : IDomainService
	{
		Service Update(UpdateServiceRequest updateServiceRequest);
	}
}
