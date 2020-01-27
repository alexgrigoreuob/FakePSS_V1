namespace NS.Booking.Domain.Pax.Exceptions
{
    using System;
    using System.Runtime.Serialization;

    [Serializable]
    public class PaxNotFoundException : Exception
    {
        public PaxNotFoundException()
        {
        }

        protected PaxNotFoundException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }

        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            base.GetObjectData(info, context);
        }
    }
}
