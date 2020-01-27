namespace NS.Booking.Domain.Pax.Models.Requests
{
    public class UpdatePaxRequest
    {
        public Pax PaxToUpdate { get; set; }

        public Pax PaxToAdd { get; set; }
    }
}
