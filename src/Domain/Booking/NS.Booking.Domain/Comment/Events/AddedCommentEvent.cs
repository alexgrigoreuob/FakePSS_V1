namespace NS.Booking.Domain.Comment.Events
{
    using Newshore.Core.EDA.Concepts;

    public class AddedCommentEvent : IDomainEvent
    {
        public Booking.Models.Comment Comment { get; set; }
    }
}
