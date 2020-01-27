namespace NS.Booking.Domain.Booking.Services.Comments
{
    using NS.Booking.Domain.Booking.Models;

    public interface IAddCommentDomainService
    {
        void AddComment(Comment comment);
    }
}