namespace NS.Booking.Domain.BoardingPass.Models.Responses
{
    using System.IO;

    public class BoardingPassResponse
    {
        public string BoardingPassHTML { get; set; }

        public MemoryStream Result { get; set; }
    }
}
