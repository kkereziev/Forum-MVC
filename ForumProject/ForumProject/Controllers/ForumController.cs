using System.Collections.Generic;
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
            var posts = forum.Posts; 

            var postListings = posts.Select(p => new PostListingModel
                {
                    Id = p.Id,
                    AuthorId = p.User.Id,
                    AuthorRating = p.User.Rating,
                    Title = p.Title,
                    DatePosted = p.Created.ToString(),
                    RepliesCount = p.Replies.Count(),
                    Forum = BuildForumListing(p.Forum)
                });
            var forumListing = BuildForumListing(forum);
            var model=new ForumTopicModel(forumListing,postListings);
            return View(model);
        }
        
        private ForumListingModel BuildForumListing(Forum forum)
        {
            return _mapper.Map<ForumListingModel>(forum);
        }
    }
}