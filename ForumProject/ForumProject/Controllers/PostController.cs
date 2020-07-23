using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ForumProject.Data.Interfaces;
using ForumProject.Data.Models;
using ForumProject.Models.Post;
using ForumProject.Models.Reply;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ForumProject.Controllers
{
    public class PostController : Controller
    {
        private readonly IPost _postService;
        private readonly IForum _forumService;
        private static UserManager<ApplicationUser> _userManager;

        public PostController(IPost postService, IForum forumService, UserManager<ApplicationUser> userManager)
        {
            _postService = postService;
            _forumService = forumService;
            _userManager = userManager;
        }

        public IActionResult Create(int id)
        {
            //the id variable is for the forum 
            var forum = _forumService.GetById(id);

            var model=new NewPostModel
            {
                ForumName = forum.Title,
                ForumId = forum.Id,
                ForumImageUrl = forum.ImageUrl,
                AuthorName = User.Identity.Name
            };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Create(NewPostModel model)
        {
            
            var userId = _userManager.GetUserId(User);
            var user = await _userManager.FindByIdAsync(userId);
            var post = BuildPost(model, user);
            
            await _postService.Add(post);

            //TODO: Implement User Rating Management
            
            return RedirectToAction("Index", "Post", new { id=post.Id });
        }

        private Post BuildPost(NewPostModel model, ApplicationUser user)
        {
            var forum = _forumService.GetById(model.ForumId);
            return new Post
            {
                Title = model.Title,
                Content = model.Content,
                Created = DateTime.Now,
                User = user,
                Forum = forum
            };
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
            return View(model);
        }

        private IEnumerable<PostReplyModel> BuildPostListing(IEnumerable<PostReply> postReplies)
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
            });
        }
    }
}