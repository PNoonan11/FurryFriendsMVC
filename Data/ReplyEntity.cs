using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FurryFriendsMVC.Data
{
    public class ReplyEntity
    {
        [Key]
        public int Id { get; set; }
        public string Text { get; set; }
        public string UserName { get; set; }
        public DateTimeOffset DateTimeCreated { get; set; }
        public DateTimeOffset DateTimeUpdated { get; set; }
        [ForeignKey("Comment")]
        public int CommentId { get; set; }
        public CommentEntity Comment { get; set; }
    }
}