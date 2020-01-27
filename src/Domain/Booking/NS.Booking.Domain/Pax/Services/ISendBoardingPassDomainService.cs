namespace NS.Booking.Domain.Pax.Services
{
    using Newshore.Core.DDD.Concepts;

    public interface ISendBoardingPassDomainService : IDomainService
    {
        void Send(string email);
    }
}
