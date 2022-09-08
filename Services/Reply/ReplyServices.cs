using FurryFriendsMVC.Data;
using FurryFriendsMVC.Models.Reply;
using Microsoft.EntityFrameworkCore;

namespace FurryFriendsMVC.Services.Reply
{
    public class ReplyServices : IReplyServices
    {
        private readonly ApplicationDbContext _DbContext;
        public ReplyServices(ApplicationDbContext DbContext)
        {

            _DbContext = DbContext;
        }

        public async Task<bool> CreateReplyAsync(ReplyCreate model)
        {
            var newReply = new ReplyEntity()
            {
                Text = model.Text,
                UserName = model.UserName,
                DateTimeCreated = DateTimeOffset.Now
            };
            _DbContext.Reply.Add(newReply);
            return await _DbContext.SaveChangesAsync() == 1;
        }

        public async Task<ReplyDetail> GetReplyByIdAsync(int replyId)
        {
            ReplyEntity replyById = await _DbContext.Reply
                .FirstOrDefaultAsync(r => r.Id == replyId);
            if (replyById == null)
                return null;
            ReplyDetail replyDetail = new ReplyDetail()
            {
                Id = replyById.Id,
                Text = replyById.Text,
                UserName = replyById.UserName,
                DateTimeCreated = replyById.DateTimeCreated,
                DateTimeUpdated = replyById.DateTimeUpdated,
                CommentId = replyById.CommentId
            };
            return replyDetail;

        }

        public async Task<List<ReplyListItem>> GetAllRepliesAsync()
        {
            List<ReplyListItem> replies = await _DbContext.Reply
            .Select(r => new ReplyListItem()
            {
                Id = r.Id,
                Text = r.Text,
                UserName = r.UserName,
                DateTimeCreated = r.DateTimeCreated,
                DateTimeUpdated = r.DateTimeUpdated,
                CommentId = r.CommentId

            }).ToListAsync();
            return replies;

        }

        public async Task<bool> EditReplyAsync(ReplyEdit model)
        {
            ReplyEntity reply = await _DbContext.Reply.FindAsync(model.Id);
            if (reply == null)
                return false;
            reply.Text = model.Text;
            reply.DateTimeUpdated = DateTimeOffset.Now;
            return await _DbContext.SaveChangesAsync() == 1;

        }

        public async Task<bool> DeleteReply(int id)
        {
            ReplyEntity reply = await _DbContext.Reply.FindAsync(id);
            if (reply == null)
                return false;

            _DbContext.Reply.Remove(reply);
            return await _DbContext.SaveChangesAsync() == 1;
        }


    }
}