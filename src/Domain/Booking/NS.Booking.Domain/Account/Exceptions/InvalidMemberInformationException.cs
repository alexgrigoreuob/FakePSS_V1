using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace NS.Booking.Domain.Account.Exceptions
{
    [Serializable]
    public class InvalidMemberInformationException : Exception
    {
        public InvalidMemberInformationException()
        {

        }

        protected InvalidMemberInformationException(SerializationInfo info, StreamingContext context)
        : base(info, context)
        {
        }

        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            base.GetObjectData(info, context);
        }
    }
}
