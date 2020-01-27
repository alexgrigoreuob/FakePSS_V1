namespace NS.Booking.Domain.Journey.Services.Validators
{
    using Conditions;
    using NS.Booking.Common.Domain.Common.Validators;
    using NS.Booking.Domain.Journey.Exceptions;
    using NS.Booking.Domain.Journey.Models;
    using System;
    using System.Collections.Generic;

    public class JourneyValidator : IValidator<Journey>
    {
        public void Validate(Journey valueToValidate)
        {
            try
            {
                ValidateRequires(valueToValidate);
                ValidateSegments(valueToValidate.Segments);
            }
            catch (Exception)
            {
                throw new InvalidJourneyInformationException();
            }
        }

        private void ValidateRequires(Journey valueToValidate)
        {
            valueToValidate.Requires().IsNotNull();
            valueToValidate.Segments.Requires().IsNotNull().IsNotEmpty();
        }

        private void ValidateSegments(List<Segment> segments)
        {
            segments.ForEach(x =>
            {
                x.Legs.Requires().IsNotNull().IsNotEmpty();
                x.Transport.Requires().IsNotNull();
                ValidateLegs(x.Legs);
            });
        }

        private void ValidateLegs(List<Leg> legs)
        {
            legs.ForEach(x =>
            {
                x.Origin.Requires().IsNotNullOrEmpty();
                x.Destination.Requires().IsNotNullOrEmpty();
                x.STA.Requires().IsGreaterThan(DateTime.MinValue);
                x.STD.Requires().IsGreaterThan(DateTime.MinValue);
                x.STAUTC.Requires().IsGreaterThan(DateTime.MinValue);
                x.STDUTC.Requires().IsGreaterThan(DateTime.MinValue);
            });
        }
    }
}
