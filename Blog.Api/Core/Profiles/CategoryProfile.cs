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
    public class CategoryProfile : Profile
    {
        public CategoryProfile()
        {
            CreateMap<Category, CategoryDto>()
                .ForMember(d => d.Posts, opt => opt.MapFrom(c => c.Posts.Select(x => new PostDto { Id = x.Id, Title = x.Title, Description = x.Description, CategoryId = x.CategoryId, ImageId = x.ImageId })));
            CreateMap<CategoryDto, Category>();
        }
    }
}
