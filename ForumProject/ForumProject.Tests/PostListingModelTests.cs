using System;
using Xunit;
using ForumProject.Models;
using ForumProject.Models.Forum;
using ForumProject.Models.Post;

namespace ForumProject.Tests
{
    public class PostListingModelTests
    {
        [Fact]
        public void PostListingModelInstantiation()
        {
            var postListing=new PostListingModel
            {
                Id = 1,
                Title = "test",
                AuthorRating = 1,
                AuthorId = "1",
                AuthorName = "test",
                RepliesCount = 1,
                DatePosted = DateTime.Now.ToString(),
                Forum = new ForumListingModel
                {
                    Id = 1,
                    Description = "test",
                    ImageUrl = "test",
                    Title = "test"
                }
            };
            Assert.True(postListing.Id==1);
            Assert.True(postListing.Forum.Id==1);
            Assert.True(postListing.Forum.Title=="test");
        }
    }
}
