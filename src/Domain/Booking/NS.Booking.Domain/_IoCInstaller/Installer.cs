namespace NS.Booking.Domain._IoCInstaller
{
    using Newshore.Core.IoC;
    using Newshore.Core.IoC.Interfaces;
    using NS.Booking.Common.Domain.Common.Validators;
    using NS.Booking.Domain.BoardingPass.Models.Requests;
    using NS.Booking.Domain.BoardingPass.Validators;
    using NS.Booking.Domain.Booking.Models;
    using NS.Booking.Domain.Booking.Models.Requests;
    using NS.Booking.Domain.Booking.Services.Validators;
    using NS.Booking.Domain.Bundles.Models.Requests;
    using NS.Booking.Domain.Bundles.Services.Validators;
    using NS.Booking.Domain.Checkin.Models.Requests;
    using NS.Booking.Domain.Checkin.Validators;
    using NS.Booking.Domain.Contact.Models;
    using NS.Booking.Domain.Contact.Services.Validators;
    using NS.Booking.Domain.Journey.Models;
    using NS.Booking.Domain.Journey.Models.Requests;
    using NS.Booking.Domain.Journey.Services.Validators;
    using NS.Booking.Domain.Pax.Models;
    using NS.Booking.Domain.Pax.Services.Validators;
    using NS.Booking.Domain.Payment.Models;
    using NS.Booking.Domain.Payment.Services.Validators;
    using NS.Booking.Domain.Search.Models.Requests;
    using NS.Booking.Domain.Search.Services.Validators;
    using NS.Booking.Domain.Service.Models.Requests;
    using NS.Booking.Domain.Service.Services.Validators;
    using System.Collections.Generic;

    public class Installer : IIoCInstaller
    {
        public void Install(LifeStyleType defaultLifeStyleType)
        {
            var components = new List<IIoCComponent>
            {
                new IoCComponent<IValidator<Contact>, ContactValidator>
                    {
                        LifeStyleType = defaultLifeStyleType
                    },
                new IoCComponent<IValidator<CreateBookingRequest>, CreateBookingRequestValidator>
                    {
                        LifeStyleType = defaultLifeStyleType
                    },
                new IoCComponent<IValidator<RetrieveBookingRequest>, RetrieveBookingRequestValidator>
                    {
                        LifeStyleType = defaultLifeStyleType
                    },
                new IoCComponent<IValidator<Booking>, BookingValidator>
                    {
                        LifeStyleType = defaultLifeStyleType
                    },
                new IoCComponent<IValidator<Pax>, PaxValidator>
                    {
                        LifeStyleType = defaultLifeStyleType
                    },
                new IoCComponent<IValidator<Payment>, PaymentValidator>
                    {
                        LifeStyleType = defaultLifeStyleType
                    },
                new IoCComponent<IValidator<CreditCardPayment>, CreditCardPaymentValidator>
                    {
                        LifeStyleType = defaultLifeStyleType
                    },
                new IoCComponent<IValidator<CreditPayment>, CreditPaymentValidator>
                    {
                        LifeStyleType = defaultLifeStyleType
                    },
                new IoCComponent<IValidator<LoyaltyPayment>, LoyaltyPaymentValidator>
                    {
                        LifeStyleType = defaultLifeStyleType
                    },
                new IoCComponent<IValidator<MobilePayment>, MobilePaymentValidator>
                    {
                        LifeStyleType = defaultLifeStyleType
                    },
                new IoCComponent<IValidator<PrePaidPayment>, PrePaidPaymentValidator>
                    {
                        LifeStyleType = defaultLifeStyleType
                    },
                new IoCComponent<IValidator<VoucherPayment>, VoucherPaymentValidator>
                    {
                        LifeStyleType = defaultLifeStyleType
                    },
                new IoCComponent<IValidator<Journey>, JourneyValidator>
                    {
                        LifeStyleType = defaultLifeStyleType
                    },
                new IoCComponent<IValidator<JourneyRequest>, JourneyRequestValidator>
                    {
                        LifeStyleType = defaultLifeStyleType
                    },
                new IoCComponent<IValidator<CheckinRequest>, CheckinRequestValidator>
                    {
                        LifeStyleType = defaultLifeStyleType
                    },
                new IoCComponent<IValidator<BoardingPassRequest>, BoardingPassRequestValidator>
                    {
                        LifeStyleType = defaultLifeStyleType
                    },
                new IoCComponent<IValidator<AddServiceRequest>, AddServiceRequestValidator>
                    {
                        LifeStyleType = defaultLifeStyleType,
                    },
                  new IoCComponent<IValidator<SearchBookingRequest>, SearchBookingRequestValidator>
                    {
                      LifeStyleType = defaultLifeStyleType
                    },
                  new IoCComponent<IValidator<AddBundleRequest>, AddBundleRequestValidator>
                    {
                      LifeStyleType = defaultLifeStyleType
                    },
                  new IoCComponent<IValidator<AutoAssignSeatRequest>, AutoAssignSeatRequestValidator>
                    {
                      LifeStyleType = defaultLifeStyleType
                    }
            };

            IoCContainer.Instance.Register(components);
        }
    }
}