﻿namespace NS.Booking.Domain.Booking.Exceptions
{
    using System;
    using System.Runtime.Serialization;

    [Serializable]
    public class BookingAlreadyExistsException : Exception
    {
        public BookingAlreadyExistsException()
        {
        }

        protected BookingAlreadyExistsException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }

        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            base.GetObjectData(info, context);
        }
    }
}
