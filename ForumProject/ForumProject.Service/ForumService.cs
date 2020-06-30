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
            var forum = _context.Forums
                .Where(x => x.Id == id)
                .Include(p=>p.Posts)
                    .ThenInclude(u=>u.User)
                .Include(f=>f.Posts)
                    .ThenInclude(r=>r.Replies)
                        .ThenInclude(r=>r.User)
                .FirstOrDefault();
            
            return forum;
        }

        public IEnumerable<Forum> GetAll()
        {
            return _context.Forums
                 .Include(x=>x.Posts);
        }

        public IEnumerable<ApplicationUser> GetAllActiveUsers()
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
