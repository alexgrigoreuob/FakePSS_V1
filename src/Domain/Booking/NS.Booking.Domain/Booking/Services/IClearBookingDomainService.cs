namespace NS.Booking.Domain.Booking.Services
{
    using Newshore.Core.DDD.Concepts;

    public interface IClearBookingDomainService : IDomainService
    {
        void Clear();
    }
}