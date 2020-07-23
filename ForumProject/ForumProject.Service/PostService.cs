using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ForumProject.Data;
using ForumProject.Data.Interfaces;
using ForumProject.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace ForumProject.Service
{
    public class PostService : IPost
    {
        private readonly ApplicationDbContext _context;
        public PostService(ApplicationDbContext context)
        {
            this._context = context;
        }

        public Post GetById(int id)
        {
            return _context.Posts
                .Include(p=>p.Replies)
                .Include(p=>p.Replies)
                    .ThenInclude(r=>r.User)
                .Include(p=>p.Forum)
                    .ThenInclude(u=>u.Posts)
                        .ThenInclude(u=>u.User)
                .FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<Post> GetAll()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Post> GetFilteredPosts(string searchQuery)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Post> GetPostsByForum(int id)
        {
            return _context.Forums
                .First(x => x.Id == id)
                .Posts;
        }

        public async Task Add(Post post)
        {
            _context.Add(post);
            await _context.SaveChangesAsync();
        }

        public Task Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task EditPostContent(int id)
        {
            throw new NotImplementedException();
        }

        public Task AddReply(PostReply reply)
        {
            throw new NotImplementedException();
        }
    }
}
