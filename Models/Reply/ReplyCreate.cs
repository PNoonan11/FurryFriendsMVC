namespace FurryFriendsMVC.Models.Reply
{
    public class ReplyCreate
    {

        public string Text { get; set; }
        public string UserName { get; set; }
        public DateTimeOffset DateTimeCreated { get; set; }

    }
}