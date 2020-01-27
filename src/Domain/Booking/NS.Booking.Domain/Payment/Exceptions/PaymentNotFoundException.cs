namespace NS.Booking.Domain.Payment.Exceptions
{
    using System;
    using System.Runtime.Serialization;

    [Serializable]
    public class PaymentNotFoundException : Exception
    {
        public PaymentNotFoundException()
        {
        }

        protected PaymentNotFoundException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }

        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            base.GetObjectData(info, context);
        }
    }
}
