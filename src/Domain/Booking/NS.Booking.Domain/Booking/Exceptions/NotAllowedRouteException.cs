namespace NS.Booking.Domain.Booking.Exceptions
{
    using System;
    using System.Runtime.Serialization;

    [Serializable]
    public class NotAllowedRouteException : Exception
    {
        public NotAllowedRouteException()
        {
        }

        protected NotAllowedRouteException(SerializationInfo info, StreamingContext context)
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
