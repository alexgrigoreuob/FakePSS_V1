namespace NS.Booking.Domain.Booking.Models.Requests
{
    using Newshore.Core.IoC;
    using NS.Booking.Common.Domain.Common.Validators;
    using System.Collections.Generic;

    public class CreateBookingRequest
    {
        private readonly List<IValidator<CreateBookingRequest>> validators;

        public CreateBookingRequest()
        {
            this.validators = IoCContainer.Instance.ResolveAll<IValidator<CreateBookingRequest>>();
        }

        public Booking Booking { get; set; }

        public void Validate()
        {
            this.validators.ForEach(x => x.Validate(this));
        }
    }
}