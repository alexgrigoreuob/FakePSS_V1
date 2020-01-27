namespace NS.Booking.Domain.Booking.Exceptions
{
    using System;
    using System.Runtime.Serialization;

    [Serializable]
    public class NotAllowedBookingStatusException : Exception
    {
        public NotAllowedBookingStatusException()
        {
        }

        protected NotAllowedBookingStatusException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }

        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            base.GetObjectData(info, context);
        }
    }
}
