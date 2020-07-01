using AutoMapper;
using Blog.Application.DataTransfer;
using Blog.Application.Exceptions;
using Blog.Application.Queries;
using Blog.EfDataAccess;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Implementation.Queries
{
    public class EfGetOneUserQuery : IGetOneUserQuery
    {
        private readonly BlogContext _context;
        private readonly IMapper _mapper;

        public EfGetOneUserQuery(BlogContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public int Id => 9;

        public string Name => "Search One User";

        public UserDto Execute(int search)
        {
            var user = _context.Users.Find(search);

            if(user == null)
            {
                throw new EntityNotFoundException(search, typeof(UserDto));
            }

            var response = _mapper.Map<UserDto>(user);

            return response;
        }
    }
}
