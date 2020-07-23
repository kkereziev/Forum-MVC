using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ForumProject.Data.Models;

namespace ForumProject.Data.Interfaces
{
    public interface IPost
    {
        Post GetById(int id);
        IEnumerable<Post> GetAll();
        IEnumerable<Post> GetFilteredPosts(string searchQuery);
        IEnumerable<Post> GetPostsByForum(int id);


        Task Add(Post post);
        Task Delete(int id);
        Task EditPostContent(int id);
        Task AddReply(PostReply reply);

    }
}
