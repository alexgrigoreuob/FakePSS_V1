using NS.Booking.Pricing.Domain.Fee.Models.Requests;

namespace NS.Booking.Pricing.Domain.Fee.Services
{
    public interface IRetrieveFeeDomainService
    {
        Models.Fee Retrieve(RetrieveFeeRequest retrieveFeeRequest);
    }
}
