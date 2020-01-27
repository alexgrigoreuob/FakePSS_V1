namespace NS.Booking.Infrastructure.Fake.Booking._IoCInstaller
{
    using Newshore.Core.IoC;
    using Newshore.Core.IoC.Interfaces;
    using NS.Booking.Domain.Booking.Services;
    using NS.Booking.Infrastructure.Fake.Booking.Services;
    using System.Collections.Generic;

    public class Installer : IIoCInstaller
    {
        public void Install(LifeStyleType defaultLifeStyleType)
        {
            var coreComponents = new List<IIoCComponent>
            {
                new IoCComponent<ISaveBookingDomainService, SaveBookingDomainService>
                {
                    LifeStyleType = defaultLifeStyleType
                },
                new IoCComponent<IRetrieveBookingDomainService, RetrieveBookingDomainService>
                {
                    LifeStyleType = defaultLifeStyleType
                },
                new IoCComponent<IReloadBookingDomainService, ReloadBookingDomainService>
                    {
                        LifeStyleType = defaultLifeStyleType
                    },
                new IoCComponent<IGenerateEticketsDomainService, EticketsGeneratorDomainService>
                    {
                        LifeStyleType = defaultLifeStyleType
                    }
            };
            IoCContainer.Instance.Register(coreComponents);
        }
    }
}