namespace NS.Booking.Domain.Fee.Services
{
    using Newshore.Core.DDD.Concepts;
    using NS.Booking.Domain.Fee.Models.Requests;

    public interface IRemoveFeeDomainService : IDomainService
    {
        void Remove(RemoveFeeRequest removeFeeRequest);
    }
}
