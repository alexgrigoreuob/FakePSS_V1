namespace NS.Booking.Domain.Booking.Models.Requests
{
    using NS.Booking.Domain.Booking.Models.Base;

    public class SendBoardingPassQueueRequest : SendBoardingPassRequestBase
    {
        public string QueueCode { get; set; }
    }
}
