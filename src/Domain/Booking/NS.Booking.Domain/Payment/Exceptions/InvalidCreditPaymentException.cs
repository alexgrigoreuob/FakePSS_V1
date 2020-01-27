namespace NS.Booking.Domain.Payment.Exceptions
{
    using System;
    using System.Runtime.Serialization;

    [Serializable]
    public class InvalidCreditPaymentException : InvalidPaymentException
    {
        public InvalidCreditPaymentException(string message) : base(message)
        {
        }

        protected InvalidCreditPaymentException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }

        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            base.GetObjectData(info, context);
        }
    }
}
