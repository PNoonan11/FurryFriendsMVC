using FurryFriendsMVC.Data;
using FurryFriendsMVC.Models.Post;
using Microsoft.EntityFrameworkCore;

namespace FurryFriendsMVC.Services.Post
{
    public class PostServices : IPostServices
    {


        private readonly ApplicationDbContext _DbContext;
        public PostServices(ApplicationDbContext DbContext)
        {

            _DbContext = DbContext;
        }

        public async Task<bool> CreatePostAsync(PostCreate model)
        {
            var posts = new PostEntity()
            {
                Text = model.Text,
                UserName = model.UserName,
                DateTimeCreated = DateTimeOffset.Now
            };
            _DbContext.Post.Add(posts);
            return await _DbContext.SaveChangesAsync() == 1;
        }

        public async Task<PostDetail> GetPostByIdAsync(int postId)
        {
            PostEntity posts = await _DbContext.Post
                .FirstOrDefaultAsync(r => r.Id == postId);
            if (posts == null)
                return null;
            PostDetail postDetail = new PostDetail()
            {
                Id = posts.Id,
                Text = posts.Text,
                UserName = posts.UserName,
                DateTimeCreated = posts.DateTimeCreated,
                DateTimeUpdated = posts.DateTimeUpdated,
                OwnerId = posts.OwnerId
            };
            return postDetail;

        }

        public async Task<List<PostListItem>> GetAllPostsAsync()
        {
            List<PostListItem> posts = await _DbContext.Post
             .Select(r => new PostListItem()
             {
                 Id = r.Id,
                 Text = r.Text,
                 UserName = r.UserName,
                 DateTimeCreated = r.DateTimeCreated,
                 DateTimeUpdated = r.DateTimeUpdated,
                 OwnerId = r.OwnerId

             }).ToListAsync();
            return posts;

        }

        public async Task<bool> EditPostAsync(PostEdit model)
        {
            PostEntity post = await _DbContext.Post.FindAsync(model.Id);
            if (post == null)
                return false;
            post.Text = model.Text;
            post.DateTimeUpdated = DateTimeOffset.Now;
            return await _DbContext.SaveChangesAsync() == 1;

        }

        public async Task<bool> DeletePost(int id)
        {
            PostEntity post = await _DbContext.Post.FindAsync(id);
            if (post == null)
                return false;

            _DbContext.Post.Remove(post);
            return await _DbContext.SaveChangesAsync() == 1;
        }


    }
}