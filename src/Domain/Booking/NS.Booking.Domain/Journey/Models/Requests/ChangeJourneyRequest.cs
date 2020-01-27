namespace NS.Booking.Domain.Journey.Models.Requests
{
    public class ChangeJourneyRequest
    {
        public Journey JourneyToChange { get; set; }

        public JourneyRequest JourneyToAdd { get; set; }
    }
}
