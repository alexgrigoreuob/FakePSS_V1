namespace NS.Booking.Common.Domain.Common.Filters
{
    public interface IFilter<in T>
    {
        int Order { get; set; }
        string Name { get; }

        void Filter(T valueToFilter);
    }
}