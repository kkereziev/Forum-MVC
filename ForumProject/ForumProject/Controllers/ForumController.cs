using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using AutoMapper;
using ForumProject.Data.Interfaces;
using ForumProject.Data.Models;
using ForumProject.Models.Forum;
using ForumProject.Models.Post;
using Microsoft.AspNetCore.Mvc;

namespace ForumProject.Controllers
{
    public class ForumController : Controller
    {
        private readonly IForum _forumService;
        private readonly IPost _postService;
        private readonly IMapper _mapper;

        public ForumController(IForum forumService,IPost postService,IMapper mapper)
        {
            this._forumService = forumService;
            this._postService = postService;
            this._mapper = mapper;
        }
        public IActionResult Index()
        {

            var forums = _mapper.Map<List<ForumListingModel>>(_forumService
                .GetAll());
            var model=new ForumIndexModel(forums);

            return View(model);
        }

        public IActionResult Topic(int id)
        {
            var forum = _forumService.GetById(id);
            var posts = forum.Posts.ToList();
            var postListings = posts.Select(post => new PostListingModel
            {
                Id = post.Id,
                AuthorRating = post.User.Rating,
                AuthorName = post.User.UserName,
                AuthorId = post.User.Id,
                Title = post.Title,
                DatePosted = post.Created.ToString(),
                RepliesCount = post.Replies.Count(),
                Forum = BuildForumListing(post)

            });

            var forumListing = BuildForumListing(forum);
            var model=new ForumTopicModel(forumListing, postListings);
            return View(model);
        }

        private ForumListingModel BuildForumListing(Forum forum)
        {
            return new ForumListingModel
            {
                Id = forum.Id,
                Title = forum.Title,
                Description = forum.Description,
                ImageUrl = forum.ImageUrl
            };

        }

        private ForumListingModel BuildForumListing(Post post)
        {
            var forum = post.Forum;

            return BuildForumListing(forum);
        }
    }
}