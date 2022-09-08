namespace FurryFriendsMVC.Models.Comment
{
    public class CommentCreate
    {


        public string Text { get; set; }
        public string UserName { get; set; }
        public DateTimeOffset DateTimeCreated { get; set; }



    }
}