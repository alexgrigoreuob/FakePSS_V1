namespace NS.Booking.Domain.Pax.Exceptions
{
    using System;
    using System.Runtime.Serialization;

    [Serializable]
    public class UnavailablePaxCheckinException : Exception
    {
        public UnavailablePaxCheckinException()
        {
        }

        protected UnavailablePaxCheckinException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }

        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            base.GetObjectData(info, context);
        }
    }
}