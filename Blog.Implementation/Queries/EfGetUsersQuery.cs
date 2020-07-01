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
    public class EfGetUsersQuery : IGetUsersQuery
    {
        private readonly BlogContext _context;
        private readonly IMapper _mapper;

        public EfGetUsersQuery(BlogContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public int Id => 8;

        public string Name => "Users Search";

        public PagedResponse<UserDto> Execute(UserSearch search)
        {
            var query = _context.Users.AsQueryable();

            if(!string.IsNullOrEmpty(search.FirstName) || !string.IsNullOrWhiteSpace(search.FirstName))
            {
                query = query.Where(x => x.FirstName.ToLower().Contains(search.FirstName.ToLower()));
            }

            if (!string.IsNullOrEmpty(search.LastName) || !string.IsNullOrWhiteSpace(search.LastName))
            {
                query = query.Where(x => x.LastName.ToLower().Contains(search.LastName.ToLower()));
            }

            if (!string.IsNullOrEmpty(search.Username) || !string.IsNullOrWhiteSpace(search.Username))
            {
                query = query.Where(x => x.Username.ToLower().Contains(search.Username.ToLower()));
            }

            var skipCount = search.PerPage * (search.Page - 1);

            var response = new PagedResponse<UserDto>
            {
                CurrentPage = search.Page,
                ItemsPerPage = search.PerPage,
                TotalCount = query.Count(),
                Items = query.Skip(skipCount).Take(search.PerPage).Select(x => _mapper.Map<UserDto>(x)).ToList()
            };

            return response;
        }
    }
}
