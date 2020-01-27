namespace NS.Booking.Common.Domain.Common.Validators
{
    public interface IValidator<in T>
    {
        void Validate(T valueToValidate);
    }
}
