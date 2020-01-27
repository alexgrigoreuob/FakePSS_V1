namespace NS.Booking.Infrastructure.Fake.Resources._IoCInstaller
{
    using Newshore.Core.IoC;
    using Newshore.Core.IoC.Interfaces;
    using Newshore.Core.Serialization;
    using NS.Booking.Infrastructure.Fake.Resources.SeatMap.Models.Configuration;
    using NS.Booking.Infrastructure.Fake.Resources.SeatMap.Services;
    using NS.Booking.Resources.Domain.SeatMap.Services;
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using System.Configuration;
    using System.IO;

    public class Installer : IIoCInstaller
    {
        public void Install(LifeStyleType defaultLifeStyleType)
        {

            var configurationTransport = File.ReadAllText(AppDomain.CurrentDomain.BaseDirectory + "/config/TransportsConfiguration.json");
            var transportsConfiguration = new JsonSerializer().Deserialize<ConfigTransports>(configurationTransport);

            if (transportsConfiguration?.Transports == null || !transportsConfiguration.Transports.Any())
            {
                throw new ConfigurationErrorsException("Invalid content for TransportsConfiguration.json file");
            }

            var coreComponents = new List<IIoCComponent>
            {
                new IoCComponent<IRetrieveSeatMapDomainService, RetrieveSeatMapDomainService>
                {
                    LifeStyleType = defaultLifeStyleType,
                    Dependencies = new Dictionary<string, object>
                    {
                        {"transportsConfiguration", transportsConfiguration}
                    }
                }
            };
            IoCContainer.Instance.Register(coreComponents);
        }
    }
}