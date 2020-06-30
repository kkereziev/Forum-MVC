using System.Linq;
using ForumProject.Data.Interfaces;
using ForumProject.Models.Forum;
using Microsoft.AspNetCore.Mvc;

namespace ForumProject.Controllers
{
    public class ForumController : Controller
    {
        private readonly IForum _forumService;
        private readonly IPost _postService;
        public ForumController(IForum forumService)
        {
            this._forumService = forumService;
        }
        public IActionResult Index()
        {
            var forums = _forumService
                .GetAll()
                .Select(x=>new ForumListingModel
                {
                    Id = x.Id,
                    Title = x.Title,
                    Description = x.Description
                });
            var model=new ForumIndexModel(forums);

            return View(model);
        }

        public IActionResult Topic(int id)
        {
            var forum = _forumService.GetById(id);
            var posts = _postService.GetFilteredPosts(id);
            return View();
        }
    }
}