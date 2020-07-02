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
        ICollection<Post> GetAll();
        ICollection<Post> GetFilteredPosts(string searchQuery);
        ICollection<Post> GetPostsByForum(int id);


        Task Add(Post post);
        Task Delete(int id);
        Task EditPostContent(int id);
        Task AddReply(PostReply reply);

    }
}
