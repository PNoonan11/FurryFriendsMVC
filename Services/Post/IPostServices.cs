using FurryFriendsMVC.Models.Post;

namespace FurryFriendsMVC.Services.Post
{
    public interface IPostServices
    {
        Task<List<PostListItem>> GetAllPostsAsync();
        Task<bool> CreatePostAsync(PostCreate model);
        Task<PostDetail> GetPostByIdAsync(int postId);
        Task<bool> EditPostAsync(PostEdit model);
        Task<bool> DeletePost(int id);

    }
}