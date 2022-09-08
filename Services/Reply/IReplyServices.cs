using FurryFriendsMVC.Models.Reply;

namespace FurryFriendsMVC.Services.Reply
{
    public interface IReplyServices
    {
        Task<bool> CreateReplyAsync(ReplyCreate model);
        Task<ReplyDetail> GetReplyByIdAsync(int replyId);
        Task<List<ReplyListItem>> GetAllRepliesAsync();
        Task<bool> EditReplyAsync(ReplyEdit model);
        Task<bool> DeleteReply(int id);

    }
}