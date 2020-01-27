namespace NS.Booking.Domain.Search.Exceptions
{
    using System;
    using System.Runtime.Serialization;

    [Serializable]
    public class InvalidSearchInformationException : Exception
    {
        public InvalidSearchInformationException()
        {
        }

        protected InvalidSearchInformationException(SerializationInfo info, StreamingContext context)
           : base(info, context)
        {
        }

        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            base.GetObjectData(info, context);
        }
    }
}
