namespace NS.Booking.Domain.Payment.Exceptions
{
    using System;
    using System.Runtime.Serialization;

    [Serializable]
    public class InvalidCreditCardPaymentException : InvalidPaymentException
    {
        public InvalidCreditCardPaymentException(string message) : base(message)
        {
        }

        protected InvalidCreditCardPaymentException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }

        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            base.GetObjectData(info, context);
        }
    }
}
