namespace NS.Booking.Domain.Booking.Exceptions
{
    using System;
    using System.Runtime.Serialization;

    [Serializable]
    public class NotAllowedStationException : Exception
    {
        public NotAllowedStationException()
        {
        }

        protected NotAllowedStationException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }

        public string Origin { get; set; }

        public string Destination { get; set; }

        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            base.GetObjectData(info, context);
        }
    }
}
