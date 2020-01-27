namespace NS.Booking.Domain.Tests.Bundle.Models
{
    using Moq;
    using Newshore.Core.EDA.Concepts;
    using Newshore.Core.IoC;
    using Newshore.Core.IoC.Interfaces;
    using NS.Booking.Common.Domain.PricedItem.Enums;
    using NS.Booking.Common.Domain.Service.Enums;
    using NS.Booking.Domain.Bundles.Events;
    using NS.Booking.Domain.Bundles.Models;
    using NS.Booking.Domain.Bundles.Services;
    using NUnit.Framework;
    using System.Collections.Generic;
    using System.Configuration;

    [TestFixture]
    public class BundleTest
    {
        private readonly IIoCContainer instance = IoCContainer.Instance;
        private readonly List<IRemoveBundleDomainService> removeBundlesDomains = new List<IRemoveBundleDomainService>();
        private Mock<IRemoveBundleDomainService> removeBundlesDomainMock;
        private Mock<IEventDispatcher> eventDispatcherMock;
        private Mock<IIoCContainer> iocContainerMock;

        [SetUp]
        public void Setup()
        {
            this.iocContainerMock = new Mock<IIoCContainer>(MockBehavior.Strict);
            IoCContainer.Instance = this.iocContainerMock.Object;
            eventDispatcherMock = new Mock<IEventDispatcher>(MockBehavior.Strict);
            removeBundlesDomainMock = new Mock<IRemoveBundleDomainService>(MockBehavior.Strict);
            this.removeBundlesDomains.Clear();
            this.removeBundlesDomains.Add(removeBundlesDomainMock.Object);
            iocContainerMock.Setup(x => x.Resolve<IEventDispatcher>(string.Empty)).Returns(eventDispatcherMock.Object);
            iocContainerMock.Setup(x => x.ResolveAll<IRemoveBundleDomainService>()).Returns(removeBundlesDomains);
        }

        [TearDown]
        public void TearDown()
        {
            eventDispatcherMock.VerifyAll();
            removeBundlesDomainMock.VerifyAll();
            iocContainerMock.VerifyAll();
            IoCContainer.Instance = this.instance;
        }

        [Test]
        public void IdIsNullWhenNoCodeIsSet()
        {
            var bundle = new Bundle();
            Assert.IsNull(bundle.Id);
        }

        [Test]
        public void IdIsNotEmptyWhenCodeIsSet()
        {
            var bundle = new Bundle
            {
                Code = "Code"
            };
            Assert.IsNotEmpty(bundle.Id);
        }

        [Test]
        public void GeneratesIdCorrectly()
        {
            var bundle = new Bundle
            {
                Code = "Code",
                ReferenceId = "ReferenceId",
                SellKey = "SellKey",
                Status = ServiceStatus.Selected,
                PaxId = "PaxId",
                Scope = ProductScopeType.PerPaxJourney
            };
            Assert.AreEqual("436F64657E5265666572656E636549647E53656C6C4B65797E50617849647E5065725061784A6F75726E6579", bundle.Id);
        }

        [Test]
        public void ThrowsWhenUnableToFindDomainServiceToRemove()
        {
            var bundle = new Bundle { Scope = ProductScopeType.PerPaxJourney };
            removeBundlesDomainMock.SetupGet(x => x.Scope).Returns(ProductScopeType.PerBooking);
            Assert.Throws<ConfigurationErrorsException>(() => { bundle.Remove(); });
        }

        [Test]
        public void RemovesTheBundleWhenValidDomainServiceFound()
        {
            var bundle = new Bundle { Scope = ProductScopeType.PerBooking };
            removeBundlesDomainMock.SetupGet(x => x.Scope).Returns(ProductScopeType.PerBooking);
            removeBundlesDomainMock.Setup(x => x.Remove(bundle));
            this.eventDispatcherMock.Setup(x => x.Dispatch(It.Is<BundleRemovedEvent>(y => y.Bundle == bundle)));
            bundle.Remove();
        }
    }
}
