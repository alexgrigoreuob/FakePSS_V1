namespace NS.Booking.Infrastructure.Fake.Pricing._IoCInstaller
{
    using System.Collections.Generic;

    using Newshore.Core.IoC;
    using Newshore.Core.IoC.Interfaces;

    using NS.Booking.Infrastructure.Fake.Pricing.Services;
    using NS.Booking.Pricing.Domain.Journey.Services;
    using NS.Booking.Pricing.Domain.Service.Services;

    public class Installer : IIoCInstaller
    {
        public void Install(LifeStyleType defaultLifeStyleType)
        {
            var coreComponents = new List<IIoCComponent>
            {
                new IoCComponent<IRetrieveJourneysPricingDomainService, JourneysPricingRetrieverDomainService>
                {
                    LifeStyleType = defaultLifeStyleType
                },
                new IoCComponent<IRetrieveServicePricingDomainService, ServicePricingRetrieverDomainService>
                {
                    Name = "ServicePricingRetrieverDomainService",
                    LifeStyleType = defaultLifeStyleType
                },
                new IoCComponent<IRetrieveServicePricingDomainService, SeatsPricingRetrieverDomainService>
                {
                    Name = "SeatsPricingRetrieverDomainService",
                    LifeStyleType = defaultLifeStyleType
                },
                new IoCComponent<IRetrieveBookingPricingDomainService, RetrieveBookingPricingDomainService>
                {
                    LifeStyleType = defaultLifeStyleType
                }
            };
            IoCContainer.Instance.Register(coreComponents);
        }
    }
}