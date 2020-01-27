namespace NS.Booking.Domain.Payment.Exceptions
{
    using System;
    using System.Runtime.Serialization;

    [Serializable]
    public class InvalidPrePaidPaymentException : InvalidPaymentException
    {
        public InvalidPrePaidPaymentException(string message) : base(message)
        {
        }

        protected InvalidPrePaidPaymentException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }

        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            base.GetObjectData(info, context);
        }
    }
}
