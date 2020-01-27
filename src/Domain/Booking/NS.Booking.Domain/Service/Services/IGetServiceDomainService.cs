namespace NS.Booking.Domain.Service.Services
{
    using Newshore.Core.DDD.Concepts;
    using NS.Booking.Domain.Service.Models;
    using System.Collections.Generic;

    public interface IGetServiceDomainService : IDomainService
    {
        List<Service> Get();
        Service Get(string Id);
    }
}
