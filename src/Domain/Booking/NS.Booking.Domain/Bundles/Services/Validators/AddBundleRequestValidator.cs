namespace NS.Booking.Domain.Bundles.Services.Validators
{
    using System;
    using Conditions;
    using NS.Booking.Common.Domain.Common.Validators;
    using NS.Booking.Domain.Bundles.Exceptions;
    using NS.Booking.Domain.Bundles.Models.Requests;

    public class AddBundleRequestValidator : IValidator<AddBundleRequest>
    {
        public void Validate(AddBundleRequest valueToValidate)
        {
            try
            {
                ValidateRequires(valueToValidate);
            }
            catch (Exception)
            {
                throw new InvalidAddBundleRequestInformationException();
            }
        }

        private static void ValidateRequires(AddBundleRequest bundleToValidate)
        {
            bundleToValidate.BundleSellKey.Requires().IsNotNullOrEmpty();
            bundleToValidate.Code.Requires().IsNotNullOrEmpty();
        }
    }
}
