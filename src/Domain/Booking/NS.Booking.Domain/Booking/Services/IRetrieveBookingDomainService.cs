namespace NS.Booking.Domain.Booking.Services
{
    using Newshore.Core.DDD.Concepts;

    using NS.Booking.Domain.Booking.Models;
    using NS.Booking.Domain.Booking.Models.Requests;

    public interface IRetrieveBookingDomainService : IDomainService
    {
        Booking Retrieve(RetrieveBookingRequest retrieveBookingRequest);
    }
}