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
    public class EfGetLogsQuery : IGetLogsQuery
    {
        private readonly BlogContext _context;
        private readonly IMapper _mapper;

        public EfGetLogsQuery(BlogContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public int Id => 22;

        public string Name => "Search Logs";

        public PagedResponse<LogDto> Execute(LogSearch search)
        {
            var query = _context.UseCaseLogs.AsQueryable();

            if(!string.IsNullOrEmpty(search.Actor) && !string.IsNullOrWhiteSpace(search.Actor))
            {
                query = query.Where(x => x.Actor.ToLower().Contains(search.Actor.ToLower()));
            }
            if (!string.IsNullOrEmpty(search.UseCaseName) && !string.IsNullOrWhiteSpace(search.UseCaseName))
            {
                query = query.Where(x => x.Actor.ToLower().Contains(search.UseCaseName.ToLower()));
            }

            var skipCount = search.PerPage * (search.Page - 1);

            var response = new PagedResponse<LogDto>
            {
                CurrentPage = search.Page,
                ItemsPerPage = search.PerPage,
                TotalCount = query.Count(),
                Items = query.Skip(skipCount).Take(search.PerPage).Select(x => _mapper.Map<LogDto>(x)).ToList()
            };

            return response;
        }
    }
}
