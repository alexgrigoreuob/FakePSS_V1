namespace NS.Booking.Infrastructure.Fake.Checkin._IoCInstaller
{
    using Newshore.Core.IoC;
    using Newshore.Core.IoC.Interfaces;
    using NS.Booking.Domain.Pax.Services;
    using NS.Booking.Infrastructure.Fake.Checkin.Services;
    using System.Collections.Generic;

    public class Installer : IIoCInstaller
    {
        public void Install(LifeStyleType defaultLifeStyleType)
        {
            var coreComponents = new List<IIoCComponent>
            {
                new IoCComponent<ICheckinPaxDomainService, CheckinPaxDomainService>
                {
                    LifeStyleType = defaultLifeStyleType
                }
            };
            IoCContainer.Instance.Register(coreComponents);
        }
    }
}