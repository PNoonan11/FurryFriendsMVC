namespace FurryFriendsMVC.Models.Post
{
    public class PostEdit
    {
        public int Id { get; set; }
        public string Text { get; set; }

        public DateTimeOffset DateTimeUpdated { get; set; }

        public PostEdit()
        {
            DateTimeUpdated = DateTimeOffset.Now;
        }


    }
}