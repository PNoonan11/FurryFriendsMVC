using FurryFriendsMVC.Data;

namespace FurryFriendsMVC.Models.Post
{
    public class PostCreate
    {

        public string Text { get; set; }
        public string UserName { get; set; }
        public DateTimeOffset DateTimeCreated { get; set; }
        public int OwnerId { get; set; }

        public PostCreate()
        {
            DateTimeCreated = DateTimeOffset.Now;
        }
    }
}