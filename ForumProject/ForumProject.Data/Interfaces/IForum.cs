using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using ForumProject.Data.Models;

namespace ForumProject.Data.Interfaces
{
    public interface IForum
    {
        Forum GetById(int id);

        ICollection<Forum> GetAll();

        ICollection<ApplicationUser> GetAllActiveUsers();

        Task Create(Forum forum);

        Task Delete(int forumId);

        Task UpdateForumTitle(int forumId, string newTitle);

        Task UpdateForumDescription(int forumId, string newDescription);

    }
}
