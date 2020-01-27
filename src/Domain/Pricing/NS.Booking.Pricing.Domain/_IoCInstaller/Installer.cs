namespace NS.Booking.Pricing.Domain._IoCInstaller
{
    using Newshore.Core.IoC;
    using Newshore.Core.IoC.Interfaces;
    using NS.Booking.Common.Domain.Common.Validators;
    using NS.Booking.Pricing.Domain.Journey.Models.Requests;
    using NS.Booking.Pricing.Domain.Journey.Services.Validators;
    using System.Collections.Generic;

    public class Installer : IIoCInstaller
    {
        public void Install(LifeStyleType defaultLifeStyleType)
        {
            var components = new List<IIoCComponent>
            {
                new IoCComponent<IValidator<JourneyPriceRequest>, JourneyPriceRequestValidator>
                    {
                        LifeStyleType = defaultLifeStyleType
                    }
            };
            IoCContainer.Instance.Register(components);
        }
    }
}