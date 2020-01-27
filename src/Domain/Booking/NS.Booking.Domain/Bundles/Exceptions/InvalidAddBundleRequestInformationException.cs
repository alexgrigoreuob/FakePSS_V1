namespace NS.Booking.Domain.Bundles.Exceptions
{
    using System;
    using System.Runtime.Serialization;

    [Serializable]
    public class InvalidAddBundleRequestInformationException : Exception
    {
        public InvalidAddBundleRequestInformationException()
        {
        }

        protected InvalidAddBundleRequestInformationException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }

        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            base.GetObjectData(info, context);
        }
    }
}
