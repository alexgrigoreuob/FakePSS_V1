namespace NS.Booking.Domain.Pax.Exceptions
{
    using System;
    using System.Runtime.Serialization;

    [Serializable]
    public class InvalidPaxInformationException : Exception
    {
        public InvalidPaxInformationException()
        {
        }

        protected InvalidPaxInformationException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }

        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            base.GetObjectData(info, context);
        }
    }
}