namespace NS.Booking.Domain.Pax.Exceptions
{
    using System;
    using System.Runtime.Serialization;

    [Serializable]
    public class CanNotCheckinException : Exception
    {
        public CanNotCheckinException()
        {
        }

        protected CanNotCheckinException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }

        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            base.GetObjectData(info, context);
        }
    }
}