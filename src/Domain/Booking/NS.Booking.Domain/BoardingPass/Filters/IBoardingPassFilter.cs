namespace NS.Booking.Domain.BoardingPass.Filters
{
    using NS.Booking.Common.Domain.Common.Filters;

    public interface IBoardingPassFilter<in T> : IFilter<T>
    {
    }
}