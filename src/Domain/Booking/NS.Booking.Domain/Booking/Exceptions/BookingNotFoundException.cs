namespace NS.Booking.Domain.Booking.Exceptions
{
    using System;
    using System.Runtime.Serialization;

    [Serializable]
    public class BookingNotFoundException : Exception
    {
        public BookingNotFoundException()
        {
        }

        protected BookingNotFoundException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }

        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            base.GetObjectData(info, context);
        }
    }
}
