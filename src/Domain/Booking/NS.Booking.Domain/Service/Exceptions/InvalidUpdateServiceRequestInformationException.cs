namespace NS.Booking.Domain.Service.Exceptions
{
    using System;
    using System.Runtime.Serialization;

    [Serializable]
    public class InvalidUpdateServiceRequestInformationException : Exception
    {
        public InvalidUpdateServiceRequestInformationException()
        {
        }

        protected InvalidUpdateServiceRequestInformationException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }

        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            base.GetObjectData(info, context);
        }
    }
}
