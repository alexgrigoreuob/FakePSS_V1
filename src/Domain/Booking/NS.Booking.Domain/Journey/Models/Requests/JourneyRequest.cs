namespace NS.Booking.Domain.Journey.Models.Requests
{
    using Newshore.Core.IoC;
    using NS.Booking.Common.Domain.Common.Validators;
    using System.Collections.Generic;

    public class JourneyRequest
    {
        private readonly List<IValidator<JourneyRequest>> _validators;

        public JourneyRequest()
        {
            _validators = IoCContainer.Instance.ResolveAll<IValidator<JourneyRequest>>();
        }

        public string JourneyId { get; set; }

        public string FareId { get; set; }

        public void Validate()
        {
            _validators.ForEach(x => x.Validate(this));
        }
    }
}
