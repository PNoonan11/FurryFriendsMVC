namespace FurryFriendsMVC.Models.Comment
{
    public class CommentEdit
    {

        public int Id { get; set; }
        public string Text { get; set; }
        public DateTimeOffset DateTimeUpdated { get; set; }
        public CommentEdit()
        {
            DateTimeUpdated = DateTimeOffset.Now;
        }
    }
}