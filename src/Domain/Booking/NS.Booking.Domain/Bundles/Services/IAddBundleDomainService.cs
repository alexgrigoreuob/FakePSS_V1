namespace NS.Booking.Domain.Bundles.Services
{
    using NS.Booking.Domain.Bundles.Models;
    using NS.Booking.Domain.Bundles.Models.Requests;

    public interface IAddBundleDomainService : IBundleDomainServiceBase
    {
        Bundle Add(AddBundleRequest addBundleRequest);
    }
}
