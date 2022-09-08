using System.Text.Json.Serialization;

namespace FurryFriendsMVC.Models
{
    public class CommentViewModel
    {


        [JsonPropertyName("text")]
        public string Text { get; set; }

        [JsonPropertyName("username")]
        public string UserName { get; set; }

        [JsonPropertyName("datetimecreated")]
        public DateTimeOffset DateTimeCreated { get; set; }

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