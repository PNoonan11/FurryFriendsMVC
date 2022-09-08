using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FurryFriendsMVC.Data
{
    public class CommentEntity
    {
        [Key]
        public int Id { get; set; }
        public string Text { get; set; }
        public string UserName { get; set; }
        public DateTimeOffset DateTimeCreated { get; set; }
        public DateTimeOffset DateTimeUpdated { get; set; }
        [ForeignKey("RelatedPost")]
        public int PostId { get; set; }
        public PostEntity RelatedPost { get; set; }
    }
}