namespace NS.Booking.Domain.Fee.Services
{
    using NS.Booking.Domain.Fee.Models.Requests;

    public interface IAddFeeDomainService : IFeeDomainServiceBase
    {
        void Add(AddFeeRequest addFeeRequest);
    }
}
