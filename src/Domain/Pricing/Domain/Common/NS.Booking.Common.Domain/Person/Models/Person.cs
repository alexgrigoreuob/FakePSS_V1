namespace NS.Booking.Common.Domain.Person.Models
{
    using System;
    using System.Collections.Generic;

    public class Person
    {
        public Person()
        {
            this.Documents = new List<PersonDocument>();
            this.Channels = new List<PersonCommunicationChannel>();
        }

        public PersonName Name { get; set; }

        public PersonAddress Address { get; set; }

        public List<PersonDocument> Documents { get; set; }

        public PersonInfo PersonInfo { get; set; }

        public List<PersonCommunicationChannel> Channels { get; set; }
    }
}