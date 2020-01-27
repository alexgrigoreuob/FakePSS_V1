namespace NS.Booking.Domain.Manage.Filters
{
    using NS.Booking.Common.Domain.Common.Filters;

    public interface IManageFilter<in T> : IFilter<T>
    {
    }
}
