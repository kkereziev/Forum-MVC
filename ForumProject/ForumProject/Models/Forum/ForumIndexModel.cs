using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ForumProject.Models.Forum
{
    public class ForumIndexModel
    {
        public ForumIndexModel(ICollection<ForumListingModel> forums)
        {
            this.ForumList = forums;
        }
        public IEnumerable<ForumListingModel> ForumList { get; set; }
    }
}
