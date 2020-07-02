using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ForumProject.Data;
using ForumProject.Data.Interfaces;
using ForumProject.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace ForumProject.Service
{
    public class ForumService : IForum
    {
        private readonly ApplicationDbContext _context;
        public ForumService(ApplicationDbContext context)
        {
            this._context = context;
        }

        public Forum GetById(int id)
        {
            var forum = _context.Forums.Where(f => f.Id == id)
                .Include(f => f.Posts)
                    .ThenInclude(f => f.User)
                .Include(f => f.Posts)
                    .ThenInclude(f => f.Replies)
                        .ThenInclude(f => f.User)
                .Include(f => f.Posts)
                    .ThenInclude(p => p.Forum)
                .FirstOrDefault();
           
            return forum;
        }

        public ICollection<Forum> GetAll()
        {
            return _context.Forums
                 .Include(x=>x.Posts).ToList();
        }

        public ICollection<ApplicationUser> GetAllActiveUsers()
        {
            throw new System.NotImplementedException();
        }

        public Task Create(Forum forum)
        {
            throw new System.NotImplementedException();
        }

        public Task Delete(int forumId)
        {
            throw new System.NotImplementedException();
        }

        public Task UpdateForumTitle(int forumId, string newTitle)
        {
            throw new System.NotImplementedException();
        }

        public Task UpdateForumDescription(int forumId, string newDescription)
        {
            throw new System.NotImplementedException();
        }
    }
}
