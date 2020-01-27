namespace NS.Booking.Domain.BoardingPass.Exceptions
{
    using System;
    using System.Runtime.Serialization;

    [Serializable]
    public class InvalidRetrieveBoardingPassRequestInformationException : Exception
    {
        public InvalidRetrieveBoardingPassRequestInformationException()
        {
        }

        protected InvalidRetrieveBoardingPassRequestInformationException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }

        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            base.GetObjectData(info, context);
        }
    }
}
