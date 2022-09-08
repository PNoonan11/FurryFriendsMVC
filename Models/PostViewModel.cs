using System.Text.Json.Serialization;
using FurryFriendsMVC.Models.Comment;

namespace FurryFriendsMVC.Models
{
    public class PostViewModel
    {


        [JsonPropertyName("text")]
        public string Text { get; set; }

        [JsonPropertyName("username")]
        public string UserName { get; set; }

        [JsonPropertyName("datetimecreated")]
        public DateTimeOffset DateTimeCreated { get; set; }
        public CommentDetail Comments { get; set; }

        [JsonPropertyName("url")]
        public string Url { get; set; }
        public string Id
        {
            get
            {
                return Url
                    .Split("/", StringSplitOptions.RemoveEmptyEntries)
                    .LastOrDefault();
            }
        }
    }
}