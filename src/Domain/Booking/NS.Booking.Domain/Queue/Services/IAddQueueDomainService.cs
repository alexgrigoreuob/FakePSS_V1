namespace NS.Booking.Domain.Queue.Services
{
    using Newshore.Core.DDD.Concepts;

    public interface IAddQueueDomainService : IDomainService
    {
        void AddQueue(Booking.Models.Queue queue);
    }
}
