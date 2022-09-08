using FurryFriendsMVC.Data;
using FurryFriendsMVC.Models.Comment;
using Microsoft.EntityFrameworkCore;

namespace FurryFriendsMVC.Services.Comment
{
    public class CommentServices : ICommentServices
    {
        private readonly ApplicationDbContext _DbContext;
        public CommentServices(ApplicationDbContext DbContext)
        {

            _DbContext = DbContext;
        }

        public async Task<bool> CreateCommentAsync(CommentCreate model)
        {
            var newComment = new CommentEntity()
            {
                Text = model.Text,
                UserName = model.UserName,
                DateTimeCreated = DateTimeOffset.Now
            };
            _DbContext.Comment.Add(newComment);
            return await _DbContext.SaveChangesAsync() == 1;
        }

        public async Task<CommentDetail> GetCommentByIdAsync(int commentId)
        {
            CommentEntity commentById = await _DbContext.Comment
                .FirstOrDefaultAsync(r => r.Id == commentId);
            if (commentById == null)
                return null;
            CommentDetail commentDetail = new CommentDetail()
            {
                Id = commentById.Id,
                Text = commentById.Text,
                UserName = commentById.UserName,
                DateTimeCreated = commentById.DateTimeCreated,
                DateTimeUpdated = commentById.DateTimeUpdated,
                PostId = commentById.PostId
            };
            return commentDetail;

        }

        public async Task<List<CommentListItem>> GetAllCommentsAsync()
        {
            List<CommentListItem> comments = await _DbContext.Comment
             .Select(r => new CommentListItem()
             {
                 Id = r.Id,
                 Text = r.Text,
                 UserName = r.UserName,
                 DateTimeCreated = r.DateTimeCreated,
                 DateTimeUpdated = r.DateTimeUpdated,
                 PostId = r.PostId

             }).ToListAsync();
            return comments;

        }

        public async Task<bool> EditCommentAsync(CommentEdit model)
        {
            CommentEntity comment = await _DbContext.Comment.FindAsync(model.Id);
            if (comment == null)
                return false;
            comment.Text = model.Text;
            comment.DateTimeUpdated = DateTimeOffset.Now;
            return await _DbContext.SaveChangesAsync() == 1;

        }

        public async Task<bool> DeleteComment(int id)
        {
            CommentEntity comment = await _DbContext.Comment.FindAsync(id);
            if (comment == null)
                return false;

            _DbContext.Comment.Remove(comment);
            return await _DbContext.SaveChangesAsync() == 1;
        }


    }
}