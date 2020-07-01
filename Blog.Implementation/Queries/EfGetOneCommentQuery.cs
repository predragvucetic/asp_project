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
    public class EfGetOneCommentQuery : IGetOneCommentQuery
    {
        private readonly BlogContext _context;
        private readonly IMapper _mapper;

        public EfGetOneCommentQuery(BlogContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public int Id => 18;

        public string Name => "Search One Comment";

        public CommentDto Execute(int search)
        {
            var comment = _context.Comments.Find(search);

            if(comment == null)
            {
                throw new EntityNotFoundException(search, typeof(CommentDto));
            }

            var response = _mapper.Map<CommentDto>(comment);

            return response;
        }
    }
}
