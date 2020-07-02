using System.Collections.Generic;
using System.Linq;
using ForumProject.Data.Interfaces;
using ForumProject.Data.Models;
using ForumProject.Models.Post;
using ForumProject.Models.Reply;
using Microsoft.AspNetCore.Mvc;

namespace ForumProject.Controllers
{
    public class PostController : Controller
    {
        private readonly IPost _postService;
        public PostController(IPost postService)
        {
            _postService = postService;
        }
        public IActionResult Index(int id)
        {
            var post = _postService.GetById(id);

            var model =new PostIndexModel
            {
                Id = post.Id,
                Title = post.Title,
                Created = post.Created,
                AuthorId = post.User.Id,
                AuthorRating = post.User.Rating,
                AuthorImageUrl = post.User.ProfileImageUrl,
                AuthorName = post.User.UserName,
                Content = post.Content,
                Replies = BuildPostListing(post.Replies)
            };
            return View();
        }

        private ICollection<PostReplyModel> BuildPostListing(ICollection<PostReply> postReplies)
        {
            return postReplies.Select(r => new PostReplyModel
            {
                Id = r.Id,
                Content = r.Content,
                Created = r.Created,
                AuthorId = r.User.Id,
                AuthorRating = r.User.Rating,
                AuthorName = r.User.UserName,
                AuthorImageUrl = r.User.ProfileImageUrl,
                PostId = r.Post.Id
            }).ToList();
        }
    }
}