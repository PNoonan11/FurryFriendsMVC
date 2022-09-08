using FurryFriendsMVC.Models.Comment;

namespace FurryFriendsMVC.Services.Comment
{
    public interface ICommentServices
    {
        Task<bool> CreateCommentAsync(CommentCreate model);
        Task<CommentDetail> GetCommentByIdAsync(int commentId);
        Task<List<CommentListItem>> GetAllCommentsAsync();
        Task<bool> EditCommentAsync(CommentEdit model);
        Task<bool> DeleteComment(int id);
    }
}