namespace NS.Booking.Domain.Booking.Services
{
    using Newshore.Core.DDD.Concepts;

    public interface IReloadBookingDomainService : IDomainService
    {
        void Reload();
    }
}