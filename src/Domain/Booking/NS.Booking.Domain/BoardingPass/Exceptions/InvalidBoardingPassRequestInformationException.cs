namespace NS.Booking.Domain.BoardingPass.Exceptions
{
    using System;
    using System.Runtime.Serialization;

    [Serializable]
    public class InvalidBoardingPassRequestInformationException : Exception
    {
        public InvalidBoardingPassRequestInformationException()
        {
        }

        protected InvalidBoardingPassRequestInformationException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }

        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            base.GetObjectData(info, context);
        }
    }
}
