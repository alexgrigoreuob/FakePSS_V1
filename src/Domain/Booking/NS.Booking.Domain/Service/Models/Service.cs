namespace NS.Booking.Domain.Service.Models
{
    using System.Collections.Generic;
    using System.Configuration;
    using System.Linq;

    using Newshore.Core.DDD.Concepts;
    using Newshore.Core.EDA.Concepts;
    using Newshore.Core.IoC;
    using Newshore.Core.Logger;
    using Newshore.Core.NativeObjects.Extensions;

    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    using NS.Booking.Common.Domain.PricedItem.Enums;
    using NS.Booking.Common.Domain.Service.Enums;
    using NS.Booking.Domain.Service.Events;
    using NS.Booking.Domain.Service.Services;

    public class Service : Aggregate
    {
        private readonly IEventDispatcher eventDispatcher;
        private readonly IEnumerable<IRemoveServiceDomainService> removeDomainServices;

        public Service()
        {
            this.eventDispatcher = IoCContainer.Instance.Resolve<IEventDispatcher>();
            this.removeDomainServices = IoCContainer.Instance.ResolveAll<IRemoveServiceDomainService>();
        }

        public override string Id
        {
            get
            {
                if (string.IsNullOrEmpty(this.Code))
                {
                    return null;
                }

                var value = $"{this.Code}~{this.ReferenceId}~{this.Type}~{this.SellKey}~{this.PaxId}";
                return value.EncodeHexadecimal();
            }
        }

        public string ReferenceId { get; set; }

        public string Code { get; set; }

        public string SellKey { get; set; }

        public string PaxId { get; set; }

        [JsonConverter(typeof(StringEnumConverter))]
        public ServiceStatus Status { get; set; }

		[JsonConverter(typeof(StringEnumConverter))]
		public ChangeStrategy ChangeStrategy { get; set; }

		[JsonConverter(typeof(StringEnumConverter))]
        public ServiceType Type { get; set; }

        [JsonConverter(typeof(StringEnumConverter))]
        public ProductScopeType Scope { get; set; }

        public void Remove()
        {
            var selectedServiceDomain = this.removeDomainServices.FirstOrDefault(x => x.ProductScopeType == this.Scope && x.Types.Contains(this.Type));
            if (selectedServiceDomain == null)
            {
                Logger.Instance.Fatal<Service>(new Dictionary<string, object>
                    {
                        { "Message", "Unable to find a valid service to process the request" },
                        { "ServiceType", this.Type },
                        { "ProductScopeType", this.Scope }
                    });
                throw new ConfigurationErrorsException();
            }

            selectedServiceDomain.Remove(this);
            this.eventDispatcher.Dispatch(new ServiceRemovedEvent() { Service = this });
        }
    }
}