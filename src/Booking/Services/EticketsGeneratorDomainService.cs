namespace NS.Booking.Infrastructure.Fake.Booking.Services
{
    using Newshore.Core.NativeObjects.Extensions;
    using Newshore.Core.Storage.Interfaces;

    using NS.Booking.Common.Domain.PricedItem.Enums;
    using NS.Booking.Domain.Booking.Models;
    using NS.Booking.Domain.Booking.Services;

    public class EticketsGeneratorDomainService : IGenerateEticketsDomainService
    {
        private readonly IStoreInSessionStrategy sessionStorage;

        public EticketsGeneratorDomainService(
            IStoreInSessionStrategy sessionStorage)
        {
            this.sessionStorage = sessionStorage;
        }

        public void Generate(Booking booking)
        {
            booking.Pax.ForEach(
                x =>
                    {
                        booking.Etickets.Add(new Eticket
                                                 {
                                                     PaxId = x.Id,
                                                     Code = x.Id.Substring(0, 6).EncodeHexadecimal().Substring(0, 6),
                                                     Scope = ProductScopeType.PerPax
                                            });
                    });

            this.sessionStorage.Add("DomainBooking", booking);
        }
    }
}