namespace NS.Booking.Domain.Tests.Service.Models
{
    using System.Collections.Generic;
    using System.Configuration;

    using Moq;

    using Newshore.Core.EDA.Concepts;
    using Newshore.Core.IoC;
    using Newshore.Core.IoC.Interfaces;

    using NS.Booking.Common.Domain.PricedItem.Enums;
    using NS.Booking.Common.Domain.Service.Enums;
    using NS.Booking.Domain.Service.Events;
    using NS.Booking.Domain.Service.Models;
    using NS.Booking.Domain.Service.Services;

    using NUnit.Framework;

    [TestFixture]
    public class ServiceTests
    {
        private readonly List<IRemoveServiceDomainService> removeServicesDomains = new List<IRemoveServiceDomainService>();
        private Mock<IRemoveServiceDomainService> removeServicesDomainMock;
        private Mock<IEventDispatcher> eventDispatcherMock;
        private Mock<IIoCContainer> iocContainerMock;

        [SetUp]
        public void Setup()
        {
            this.iocContainerMock = new Mock<IIoCContainer>(MockBehavior.Strict);
            IoCContainer.Instance = this.iocContainerMock.Object;
            eventDispatcherMock = new Mock<IEventDispatcher>(MockBehavior.Strict);
            removeServicesDomainMock = new Mock<IRemoveServiceDomainService>(MockBehavior.Strict);
            this.removeServicesDomains.Clear();
            this.removeServicesDomains.Add(removeServicesDomainMock.Object);
            iocContainerMock.Setup(x => x.Resolve<IEventDispatcher>(string.Empty)).Returns(eventDispatcherMock.Object);
            iocContainerMock.Setup(x => x.ResolveAll<IRemoveServiceDomainService>()).Returns(removeServicesDomains);
        }

        [TearDown]
        public void TearDown()
        {
            eventDispatcherMock.VerifyAll();
            removeServicesDomainMock.VerifyAll();
            iocContainerMock.VerifyAll();
        }

        [Test]
        public void IdIsNullWhenNoCodeIsSet()
        {
            var service = new Service();
            Assert.IsNull(service.Id);
        }

        [Test]
        public void IdIsNotEmptyWhenCodeIsSet()
        {
            var service = new Service
            {
                Code = "Code"
            };
            Assert.IsNotEmpty(service.Id);
        }

        [Test]
        public void GeneratesIdCorrectly()
        {
            var service = new Service
                              {
                                  Code = "Code",
                                  ReferenceId = "ReferenceId",
                                  SellKey = "SellKey",
                                  Type = ServiceType.Baggage,
                                  Status = ServiceStatus.Selected,
                                  PaxId = "PaxId",
                                  Scope = ProductScopeType.PerPaxJourney,
								  ChangeStrategy = ChangeStrategy.Free
            };

            Assert.AreEqual("436F64657E5265666572656E636549647E426167676167657E53656C6C4B65797E5061784964", service.Id);
        }

        [Test]
        public void ThrowsWhenUnableToFindDomainServiceToRemove()
        {
            var service = new Service { Scope = ProductScopeType.PerBooking, Type = ServiceType.Baggage };
            removeServicesDomainMock.SetupGet(x => x.ProductScopeType).Returns(ProductScopeType.PerBooking);
            removeServicesDomainMock.SetupGet(x => x.Types).Returns(new List<ServiceType>());

            Assert.Throws<ConfigurationErrorsException>(() => { service.Remove(); });
        }

        [Test]
        public void RemovesTheServiceWhenValidDomainServiceFound()
        {
            var service = new Service { Scope = ProductScopeType.PerBooking, Type = ServiceType.Baggage };
            removeServicesDomainMock.SetupGet(x => x.ProductScopeType).Returns(ProductScopeType.PerBooking);
            removeServicesDomainMock.SetupGet(x => x.Types).Returns(new List<ServiceType> { ServiceType.Baggage });
            removeServicesDomainMock.Setup(x => x.Remove(service));
            this.eventDispatcherMock.Setup(x => x.Dispatch(It.Is<ServiceRemovedEvent>(y => y.Service == service)));

            service.Remove();
        }
    }
}