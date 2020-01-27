namespace NS.Booking.Domain.BoardingPass.Services
{
    using Newshore.Core.DDD.Concepts;

    public interface IMarkBoardingPassAsSentDomainService : IDomainService
    {
        void Mark(string queueCode);
    }
}