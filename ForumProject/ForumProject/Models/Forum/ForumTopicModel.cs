using System.Collections.Generic;
using ForumProject.Models.Post;

namespace ForumProject.Models.Forum
{
    public class ForumTopicModel
    {
        public ForumTopicModel(ForumListingModel forum, IEnumerable<PostListingModel> posts)
        {
            this.Forum = forum;
            this.Posts = posts;
        }
        public ForumListingModel Forum { get; set; }
        public IEnumerable<PostListingModel> Posts { get; set; }
    }
}
