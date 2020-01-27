namespace NS.Booking.Domain.Service.Services
{
    using NS.Booking.Domain.Service.Models.Requests;
    using NS.Booking.Domain.Service.Models;

    public interface IAddServiceDomainService : IServiceDomainServiceBase
    {
        Service Add(AddServiceRequest service);

    }
}