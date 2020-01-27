namespace NS.Booking.Domain.Journey.Exceptions
{
    using System;
    using System.Runtime.Serialization;

    [Serializable]
    public class SegmentNotFoundException : Exception
    {
        public SegmentNotFoundException()
        {
        }

        protected SegmentNotFoundException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }

        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            base.GetObjectData(info, context);
        }
    }
}
