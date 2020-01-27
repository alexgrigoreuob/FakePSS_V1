namespace NS.Booking.Domain.Contact.Models
{
    using System.Collections.Generic;
    using System.Linq;

    using Newshore.Core.IoC;
    using Newshore.Core.NativeObjects.Extensions;

    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    using NS.Booking.Common.Domain.Common.Validators;
    using NS.Booking.Common.Domain.Person.Models;
    using NS.Booking.Domain.Contact.Enums;

    public class Contact : Person
    {
        private readonly List<IValidator<Contact>> validators;

        public Contact()
        {
            this.validators = IoCContainer.Instance.ResolveAll<IValidator<Contact>>();
        }

        [JsonConverter(typeof(StringEnumConverter))]
        public ContactType Type { get; set; }

        public bool MktOption { get; set; }

        public string Id
        {
            get
            {
                var info = this.Channels.Any() ? this.Channels.First().Info : string.Empty;
                var value = $"{this.Name.First}~{this.Name.Last}~{this.Type}~{info}";
                return value.EncodeHexadecimal();
            }
        }

        public void Validate()
        {
            this.validators.ForEach(x => x.Validate(this));
        }
    }
}
