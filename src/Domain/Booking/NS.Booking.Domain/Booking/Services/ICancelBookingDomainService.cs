namespace NS.Booking.Domain.Booking.Services
{
    using Newshore.Core.DDD.Concepts;

    using NS.Booking.Domain.Booking.Models;

    public interface ICancelBookingDomainService : IDomainService
    {
        void Cancel(Booking booking);
    }
}