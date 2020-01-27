namespace NS.Booking.Domain.Contact.Models.Requests
{
    public class UpdateContactRequest
    {
        public Contact ContactToUpdate { get; set; }

        public Contact ContactToAdd { get; set; }
    }
}
