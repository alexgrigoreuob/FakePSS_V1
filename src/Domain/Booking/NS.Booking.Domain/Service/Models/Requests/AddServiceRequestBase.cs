namespace NS.Booking.Domain.Service.Models.Requests
{
    public abstract class AddServiceRequestBase
    {
        public string Code { get; set; }

        public string PaxId { get; set; }

        public string SellKey { get; set; }
    }
}
