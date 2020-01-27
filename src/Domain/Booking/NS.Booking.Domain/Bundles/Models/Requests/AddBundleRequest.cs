namespace NS.Booking.Domain.Bundles.Models.Requests
{
    using System.Collections.Generic;
    using Newshore.Core.IoC;
    using NS.Booking.Common.Domain.Common.Validators;
    using NS.Booking.Domain.Service.Models.Requests;

    public class AddBundleRequest : AddServiceRequestBase
    {
        private readonly List<IValidator<AddBundleRequest>> _validators;

        public AddBundleRequest()
        {
            _validators = IoCContainer.Instance.ResolveAll<IValidator<AddBundleRequest>>();
        }

        public string BundleSellKey { get; set; }

        public void Validate()
        {
            _validators.ForEach(x => x.Validate(this));
        }
    }
}
