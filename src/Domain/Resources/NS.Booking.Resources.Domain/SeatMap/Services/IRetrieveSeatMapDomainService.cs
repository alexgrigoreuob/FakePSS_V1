namespace NS.Booking.Resources.Domain.SeatMap.Services
{
    using Newshore.Core.DDD.Concepts;
    using NS.Booking.Resources.Domain.SeatMap.Models;

    public interface IRetrieveSeatMapDomainService : IDomainService
    {
        Transport Retrieve(string SegmentId);
    }
}
