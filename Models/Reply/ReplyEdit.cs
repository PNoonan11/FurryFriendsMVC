namespace FurryFriendsMVC.Models.Reply
{
    public class ReplyEdit
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public string UserName { get; set; }

        public DateTimeOffset DateTimeUpdated { get; set; }
        public ReplyEdit()
        {
            DateTimeUpdated = DateTimeOffset.Now;
        }
    }
}