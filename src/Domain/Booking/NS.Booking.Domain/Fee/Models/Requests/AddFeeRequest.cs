namespace NS.Booking.Domain.Fee.Models.Requests
{
    public class AddFeeRequest
    {
        public string Code { get; set; }
        public string PaxId { get; set; }
        public string FeeSellKey { get; set; }
        public string SellKey { get; set; }

    }
}
