namespace NS.Booking.Domain.Payment.Exceptions
{
    using System;
    using System.Runtime.Serialization;

    [Serializable]
    public class InvalidLoyaltyPaymentException : InvalidPaymentException
    {
        public InvalidLoyaltyPaymentException(string message) : base(message)
        {
        }

        protected InvalidLoyaltyPaymentException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }

        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            base.GetObjectData(info, context);
        }
    }
}
