namespace NS.Booking.Domain.Account.Exceptions
{
    using System;
    using System.Runtime.Serialization;

    [Serializable]
    public class AccountNotFoundException : Exception
    {
        public AccountNotFoundException()
        {

        }
        protected AccountNotFoundException(SerializationInfo info, StreamingContext context)
         : base(info, context)
        {
        }

        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            base.GetObjectData(info, context);
        }
    }
}