namespace NS.Booking.Domain.Checkin.Filters
{
    using NS.Booking.Common.Domain.Common.Filters;

    public interface ICheckinFilter<in T> : IFilter<T>
    {
    }
}
