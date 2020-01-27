namespace NS.Booking.Domain.BoardingPass.Services
{
    using Newshore.Core.DDD.Concepts;

    using NS.Booking.Domain.BoardingPass.Enums;

    public interface IPerBoardingPassTypeDomainService : IDomainService
    {
        BoardingPassType Type { get; }
    }
}