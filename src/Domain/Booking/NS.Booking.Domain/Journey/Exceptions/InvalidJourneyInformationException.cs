using System;

namespace NS.Booking.Domain.Journey.Exceptions
{
    using System.Runtime.Serialization;

    [Serializable]
    public class InvalidJourneyInformationException : Exception
    {
        public InvalidJourneyInformationException()
        {
        }

        protected InvalidJourneyInformationException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }

        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            base.GetObjectData(info, context);
        }
    }
}
