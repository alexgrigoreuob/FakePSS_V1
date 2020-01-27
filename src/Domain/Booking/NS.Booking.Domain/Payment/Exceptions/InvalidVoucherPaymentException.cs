namespace NS.Booking.Domain.Payment.Exceptions
{
    using System;
    using System.Runtime.Serialization;

    [Serializable]
    public class InvalidVoucherPaymentException : InvalidPaymentException
    {
        public InvalidVoucherPaymentException(string message) : base(message)
        {
        }

        protected InvalidVoucherPaymentException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }

        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            base.GetObjectData(info, context);
        }
    }
}
