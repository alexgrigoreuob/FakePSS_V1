namespace NS.Booking.Domain.Bundles.Models
{
    using System.Collections.Generic;
    using System.Configuration;
    using System.Linq;
    using Newshore.Core.DDD.Concepts;
    using Newshore.Core.EDA.Concepts;
    using Newshore.Core.IoC;
    using Newshore.Core.Logger;
    using Newshore.Core.NativeObjects.Extensions;
    using NS.Booking.Common.Domain.PricedItem.Enums;
    using NS.Booking.Common.Domain.Service.Enums;
    using NS.Booking.Domain.Bundles.Events;
    using NS.Booking.Domain.Bundles.Services;

    public class Bundle : Aggregate
    {
        private readonly IEventDispatcher eventDispatcher;
        private readonly IEnumerable<IRemoveBundleDomainService> removeDomainServices;

        public Bundle()
        {
            this.eventDispatcher = IoCContainer.Instance.Resolve<IEventDispatcher>();
            this.removeDomainServices = IoCContainer.Instance.ResolveAll<IRemoveBundleDomainService>();
            this.Services = new List<string>();
        }

        public override string Id
        {
            get
            {
                if (string.IsNullOrEmpty(this.Code))
                {
                    return null;
                }

                var value = $"{this.Code}~{this.ReferenceId}~{this.SellKey}~{this.PaxId}~{this.Scope}";
                return value.EncodeHexadecimal();
            }
        }

        public string ReferenceId { get; set; }

        public string Code { get; set; }

        public ServiceStatus Status { get; set; }

        public ProductScopeType Scope { get; set; }

        public string PaxId { get; set; }

        public string SellKey { get; set; }

        public List<string> Services { get; set; }

        public void Remove()
        {
            var selectedServiceDomain = this.removeDomainServices.FirstOrDefault(x => x.Scope == this.Scope);
            if (selectedServiceDomain == null)
            {
                Logger.Instance.Fatal<Bundle>(new Dictionary<string, object>
                    {
                        { "Message", "Unable to find a valid service to process the request" },
                        { "ProductScopeType", this.Scope }
                    });
                throw new ConfigurationErrorsException();
            }

            selectedServiceDomain.Remove(this);
            this.eventDispatcher.Dispatch(new BundleRemovedEvent() { Bundle = this });
        }
    }
}
