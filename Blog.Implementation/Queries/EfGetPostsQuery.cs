using AutoMapper;
using Blog.Application.DataTransfer;
using Blog.Application.Queries;
using Blog.Application.Searches;
using Blog.EfDataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Blog.Implementation.Queries
{
    public class EfGetPostsQuery : IGetPostsQuery
    {
        private readonly BlogContext _context;
        private readonly IMapper _mapper;

        public EfGetPostsQuery(BlogContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public int Id => 12;

        public string Name => "Posts Search";

        public PagedResponse<PostDto> Execute(PostSearch search)
        {
            var query = _context.Posts.Include(x => x.Category).Include(x => x.Image).Include(x => x.Comments).AsQueryable();

            if(!string.IsNullOrEmpty(search.Title) && !string.IsNullOrWhiteSpace(search.Title))
            {
                query = query.Where(x => x.Title.ToLower().Contains(search.Title.ToLower()));
            }

            if (!string.IsNullOrEmpty(search.Description) && !string.IsNullOrWhiteSpace(search.Description))
            {
                query = query.Where(x => x.Description.ToLower().Contains(search.Description.ToLower()));
            }

            var skipCount = search.PerPage * (search.Page - 1);

            var response = new PagedResponse<PostDto>
            {
                CurrentPage = search.Page,
                ItemsPerPage = search.PerPage,
                TotalCount = query.Count(),
                //Items = query.Skip(skipCount).Take(search.PerPage).Select(x => _mapper.Map<PostDto>(x)).ToList()
                Items = query.Skip(skipCount).Take(search.PerPage).Select(x => new PostDto
                {
                    Id = x.Id,
                    Title = x.Title,
                    Description = x.Description,
                    ImageId = x.ImageId,
                    CategoryId = x.CategoryId,
                    Comments = x.Comments
                }).ToList() // KAKO SE MAPIRA SA KOLEKCIJAMA???
            };

            return response;
        }
    }
}
