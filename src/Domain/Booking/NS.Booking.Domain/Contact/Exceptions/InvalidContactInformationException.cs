namespace NS.Booking.Domain.Contact.Exceptions
{
    using System;
    using System.Runtime.Serialization;

    [Serializable]
    public class InvalidContactInformationException : Exception
    {
        public InvalidContactInformationException()
        {
        }

        protected InvalidContactInformationException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }

        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            base.GetObjectData(info, context);
        }
    }
}