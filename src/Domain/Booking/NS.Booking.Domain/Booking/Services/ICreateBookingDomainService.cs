namespace NS.Booking.Domain.Booking.Services
{
    using Newshore.Core.DDD.Concepts;

    using NS.Booking.Domain.Booking.Models;

    public interface ICreateBookingDomainService : IDomainService
    {
        void Create(Booking booking);
    }
}