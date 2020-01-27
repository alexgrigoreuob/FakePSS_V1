namespace NS.Booking.Domain.Payment.Exceptions
{
    using System;
    using System.Runtime.Serialization;

    [Serializable]
    public class InvalidMobilePaymentException : InvalidPaymentException
    {
        public InvalidMobilePaymentException(string message) : base(message)
        {
        }

        protected InvalidMobilePaymentException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }

        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            base.GetObjectData(info, context);
        }
    }
}
