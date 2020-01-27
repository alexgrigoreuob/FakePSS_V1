namespace NS.Booking.Domain.Journey.Exceptions
{
    using System;
    using System.Runtime.Serialization;

    [Serializable]
    public class JourneyNotFoundException : Exception
    {
        public JourneyNotFoundException()
        {
        }

        protected JourneyNotFoundException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }

        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            base.GetObjectData(info, context);
        }
    }
}
