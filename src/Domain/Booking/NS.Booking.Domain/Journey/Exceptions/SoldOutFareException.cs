namespace NS.Booking.Domain.Journey.Exceptions
{
    using System;
    using System.Runtime.Serialization;

    [Serializable]
    public class SoldOutFareException : Exception
    {
        public SoldOutFareException()
        {
        }

        protected SoldOutFareException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }

        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            base.GetObjectData(info, context);
        }
    }
}
