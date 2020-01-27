namespace NS.Booking.Domain.Bundles.Services
{
    using NS.Booking.Domain.Bundles.Models;

    public interface IRemoveBundleDomainService : IBundleDomainServiceBase
    {
        void Remove(Bundle bundle);
    }
}
