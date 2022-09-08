using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FurryFriendsMVC.Data
{
    public class PostEntity
    {
        [Key]
        public int Id { get; set; }
        public string Text { get; set; }
        public string UserName { get; set; }
        public DateTimeOffset DateTimeCreated { get; set; }
        public DateTimeOffset DateTimeUpdated { get; set; }
        [ForeignKey("Owner")]
        public int OwnerId { get; set; }
        public UserEntity Owner { get; set; }
    }
}