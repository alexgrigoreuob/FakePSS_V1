namespace NS.Booking.Domain.Service.Exceptions
{
    using System;
    using System.Runtime.Serialization;

    [Serializable]
    public class InvalidAutoAssignSeatRequestInformationException : Exception
    {
        public InvalidAutoAssignSeatRequestInformationException() 
        {
        }

        protected InvalidAutoAssignSeatRequestInformationException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }

        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            base.GetObjectData(info, context);
        }
    }
}
