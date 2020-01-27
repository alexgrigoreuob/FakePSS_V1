namespace NS.Booking.Domain.Booking.Services
{
    using Newshore.Core.DDD.Concepts;

    using NS.Booking.Domain.Booking.Models;

    public interface IGetCurrentBookingDomainService : IDomainService
    {
        Booking Get();
    }
}