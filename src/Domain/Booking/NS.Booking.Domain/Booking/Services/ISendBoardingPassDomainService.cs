namespace NS.Booking.Domain.Booking.Services
{
    using Newshore.Core.DDD.Concepts;
    using NS.Booking.Domain.Booking.Enums;
    using NS.Booking.Domain.Booking.Models.Base;
    using NS.Booking.Domain.Booking.Models.Requests;

    public interface ISendBoardingPassDomainService : IDomainService
    {
        SendType Type { get; }
        void Send(SendBoardingPassRequestBase sendBoardingPassRequest);
    }
}
