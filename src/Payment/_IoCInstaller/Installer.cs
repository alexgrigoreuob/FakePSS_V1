using System.Collections.Generic;
using Newshore.Core.IoC;
using Newshore.Core.IoC.Interfaces;
using NS.Booking.Domain.Payment.Services;
using NS.Booking.Infrastructure.Fake.Payment.Services;

namespace NS.Booking.Infrastructure.Fake.Payment._IoCInstaller
{
    public class Installer : IIoCInstaller
    {
        public void Install(LifeStyleType defaultLifeStyleType)
        {
            var coreComponents = new List<IIoCComponent>
            {
                new IoCComponent<IAvailablePaymentMethodsDomainService, AvailablePaymentMethodsDomainService> {LifeStyleType = defaultLifeStyleType},
                new IoCComponent<IAddPaymentDomainService, AddCreditCardPaymentDomainService> {LifeStyleType = defaultLifeStyleType, Name = "CreditCardPaymentAdder"}
            };

            IoCContainer.Instance.Register(coreComponents);
        }
    }
}
