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
    public class EfGetCategoryQuery : IGetCategoryQuery
    {
        private readonly BlogContext _context;
        private readonly IMapper _mapper;

        public EfGetCategoryQuery(BlogContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public int Id => 3;

        public string Name => "Category Search";

        public PagedResponse<CategoryDto> Execute(CategorySearch search)
        {
            var query = _context.Categories.Include(x => x.Posts).AsQueryable();

            if(!string.IsNullOrEmpty(search.Name) || !string.IsNullOrWhiteSpace(search.Name))
            {
                query = query.Where(x => x.Name.ToLower().Contains(search.Name.ToLower()));
            }

            var skipCount = search.PerPage * (search.Page - 1);

            var response = new PagedResponse<CategoryDto>
            {
                CurrentPage = search.Page,
                ItemsPerPage = search.PerPage,
                TotalCount = query.Count(),
                //Items = query.Skip(skipCount).Take(search.PerPage).Select(x => _mapper.Map<CategoryDto>(x)).ToList()
                Items = query.Skip(skipCount).Take(search.PerPage).Select(x => new CategoryDto
                {
                    Id = x.Id,
                    Name = x.Name,
                    Posts = x.Posts
                }).ToList()
            };

            return response;
        }
    }
}
