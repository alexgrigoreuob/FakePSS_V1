namespace NS.Booking.Domain.Service.Services
{
    using NS.Booking.Domain.Service.Models;
    public interface IRemoveServiceDomainService : IServiceDomainServiceBase
    {
        void Remove(Service service);
    }
}
