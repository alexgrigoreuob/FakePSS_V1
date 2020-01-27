namespace NS.Booking.Domain.Manage.Exceptions
{
    using System;
    using System.Runtime.Serialization;

    [Serializable]
    public class InvalidManageRequestInformationException : Exception
    {
        public InvalidManageRequestInformationException()
        {
        }

        protected InvalidManageRequestInformationException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }

        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            base.GetObjectData(info, context);
        }
    }
}
