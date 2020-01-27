namespace NS.Booking.Domain.Pax.Services
{
    using NS.Booking.Domain.BoardingPass.Models.Requests;
    using NS.Booking.Domain.BoardingPass.Models.Responses;
    using NS.Booking.Domain.BoardingPass.Services;

    public interface IGenerateBoardingPassDomainService : IPerBoardingPassTypeDomainService
    {
        BoardingPassResponse Generate(BoardingPassRequest request);
    }
}