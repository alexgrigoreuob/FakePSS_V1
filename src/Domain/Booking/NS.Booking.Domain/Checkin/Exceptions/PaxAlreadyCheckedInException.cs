namespace NS.Booking.Domain.Checkin.Exceptions
{
    using System;
    using System.Runtime.Serialization;

    [Serializable]
    public class PaxAlreadyCheckedInException : Exception
    {
        public PaxAlreadyCheckedInException()
        {
        }

        protected PaxAlreadyCheckedInException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }

        public string PaxId { get; set; }

        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            base.GetObjectData(info, context);
        }
    }
}
