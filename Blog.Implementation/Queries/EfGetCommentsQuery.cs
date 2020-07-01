using AutoMapper;
using Blog.Application.DataTransfer;
using Blog.Application.Queries;
using Blog.Application.Searches;
using Blog.EfDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Blog.Implementation.Queries
{
    public class EfGetCommentsQuery : IGetCommentsQuery
    {
        private readonly BlogContext _context;
        private readonly IMapper _mapper;

        public EfGetCommentsQuery(BlogContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public int Id => 17;

        public string Name => "Comments Search";

        public PagedResponse<CommentDto> Execute(CommentSearch search)
        {
            var query = _context.Comments.AsQueryable();

            if(!string.IsNullOrEmpty(search.Content) && !string.IsNullOrWhiteSpace(search.Content))
            {
                query = query.Where(x => x.Content.ToLower().Contains(search.Content.ToLower()));
            }

            var skipCount = search.PerPage * (search.Page - 1);

            var response = new PagedResponse<CommentDto>
            {
                CurrentPage = search.Page,
                ItemsPerPage = search.PerPage,
                TotalCount = query.Count(),
                Items = query.Skip(skipCount).Take(search.PerPage).Select(x => _mapper.Map<CommentDto>(x)).ToList()
            };

            return response;
        }
    }
}
