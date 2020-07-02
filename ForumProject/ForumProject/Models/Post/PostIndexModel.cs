using System;
using System.Collections.Generic;
using ForumProject.Models.BaseClass;
using ForumProject.Models.Reply;

namespace ForumProject.Models.Post
{
    public class PostIndexModel : Message
    {
        public string Title { get; set; }

        public ICollection<PostReplyModel> Replies { get; set; }
    }
}
