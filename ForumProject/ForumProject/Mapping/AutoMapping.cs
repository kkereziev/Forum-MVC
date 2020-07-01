using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using ForumProject.Data.Models;
using ForumProject.Models.Forum;
using ForumProject.Models.Post;

namespace ForumProject.Mapping
{
    public class AutoMapping : Profile
    {
        public AutoMapping()
        {
            CreateMap<Forum, ForumListingModel>().ReverseMap();
            CreateMap<Post, PostListingModel>()
                .ForMember(x => x.AuthorId, x => x.MapFrom(y => y.User.Id))
                .ForMember(x => x.AuthorRating, x => x.MapFrom(y => y.User.Rating))
                .ForMember(x => x.DatePosted, x => x.MapFrom(y => y.Created.ToString()))
                .ForMember(x => x.RepliesCount, x => x.MapFrom(y => y.Replies.Count()));
        }
    }
}
