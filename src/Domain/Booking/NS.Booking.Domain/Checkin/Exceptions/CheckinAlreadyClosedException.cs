namespace NS.Booking.Domain.Checkin.Exceptions
{
    using System;
    using System.Runtime.Serialization;

    [Serializable]
    public class CheckinAlreadyClosedException : Exception
    {
        public CheckinAlreadyClosedException()
        {
        }

        protected CheckinAlreadyClosedException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }

        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            base.GetObjectData(info, context);
        }
    }
}
