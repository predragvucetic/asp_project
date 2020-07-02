using AutoMapper;
using Blog.Application.DataTransfer;
using Blog.Application.Searches;
using Blog.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.Api.Core.Profiles
{
    public class PostProfile : Profile
    {
        public PostProfile()
        {
            CreateMap<Post, PostDto>()
                .ForMember(d => d.Comments, opt => opt.MapFrom(p => p.Comments.Select(x => new CommentDto { Id = x.Id, Content = x.Content, PostId = x.PostId, UserId = x.UserId })));
            CreateMap<PostDto, Post>();
        }
    }
}
