namespace NS.Booking.Domain.Booking.Models.Requests
{
    using NS.Booking.Domain.Booking.Models.Base;
    using System.IO;

    public class SendBoardingPassEmailRequest :SendBoardingPassRequestBase
    {
        public string Email { get; set; }
        public MemoryStream Data { get; set; }
    }
}
