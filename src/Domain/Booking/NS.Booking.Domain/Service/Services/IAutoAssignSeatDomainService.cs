namespace NS.Booking.Domain.Service.Services
{
    using NS.Booking.Domain.Service.Models.Requests;
    using NS.Booking.Domain.Service.Models;
    using NS.Booking.Domain.Service.Enums;

    public interface IAutoAssignSeatDomainService : IServiceDomainServiceBase
    {
        void Assign(AutoAssignSeatRequest autoAssignSeat);

        AutoAssignStrategyType AutoAssignStrategy { get; set; }

    }
}