namespace FurryFriendsMVC.Models.Post
{
    public class PostListItem
    {
        public int Id { get; set; }
        public string Text { get; set; }

        public string UserName { get; set; }
        public DateTimeOffset DateTimeCreated { get; set; }
        public DateTimeOffset DateTimeUpdated { get; set; }

        public int OwnerId { get; set; }
    }
}