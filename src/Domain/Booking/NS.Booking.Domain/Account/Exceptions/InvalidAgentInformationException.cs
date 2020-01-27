using System;
using System.Runtime.Serialization;

namespace NS.Booking.Domain.Account.Exceptions
{
    [Serializable]
    public class InvalidAgentInformationException : Exception
    {

        public InvalidAgentInformationException()
        {

        }
        protected InvalidAgentInformationException(SerializationInfo info, StreamingContext context)
         : base(info, context)
        {
        }

        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            base.GetObjectData(info, context);
        }
    }
}
