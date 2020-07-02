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
                .FirstOrDefault(x => x.Id == id);
        }

        public ICollection<Post> GetAll()
        {
            throw new NotImplementedException();
        }

        public ICollection<Post> GetFilteredPosts(string searchQuery)
        {
            throw new NotImplementedException();
        }

        public ICollection<Post> GetPostsByForum(int id)
        {
            return _context.Forums
                .First(x => x.Id == id)
                .Posts;
        }

        public Task Add(Post post)
        {
            throw new NotImplementedException();
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
