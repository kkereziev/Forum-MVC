using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Threading.Tasks;
using ForumProject.Models.BaseClass;

namespace ForumProject.Models.Reply
{
    public class PostReplyModel: Message
    {
        public int PostId { get; set; }
    }
}
