namespace NS.Booking.Infrastructure.Fake.Resources.SeatMap.Models.Configuration
{
    using System.Collections.Generic;

    public class ConfigTransport
    {
        public string Type { get; set; }

        public string Suffix { get; set; }

        public List<ConfigDeck> Decks { get; set; }
    }
}
