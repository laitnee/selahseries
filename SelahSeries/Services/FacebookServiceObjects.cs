using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SelahSeries.Services
{
    public class FacebookPageInfo
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("og_object")]
        public FacebookPage Page { get; set; }

        [JsonProperty("share")]
        public FacebookPageShare Share { get; set; }
    }

    public class FacebookPage
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("updated_time")]
        public DateTime UpdatedTime { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }
    }
    public class FacebookPageShare
    {
        [JsonProperty("comment_count")]
        public int CommentCount { get; set; }

        [JsonProperty("share_count")]
        public int ShareCount { get; set; }
    }

    public class FacebookPageCommentInfo
    {
        public int TotalComments { get; set; }
        public List<FacebookCommentItem> Comments { get; set; }
    }

    public class FacebookCommentItem
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("created_time")]
        public DateTime CreatedTime { get; set; }

        [JsonProperty("from")]
        public FacebookCommentFrom From { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }
    }

    public class FacebookCommentFrom
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }
    }
}
