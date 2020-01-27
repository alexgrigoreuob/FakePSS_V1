namespace NS.Booking.Domain.Comment.Services
{
    using Newshore.Core.DDD.Concepts;

    public interface IAddCommentDomainService : IDomainService
    {
        void AddComment(Booking.Models.Comment comment);
    }
}
