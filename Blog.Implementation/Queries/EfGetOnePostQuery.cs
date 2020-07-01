using AutoMapper;
using Blog.Application.DataTransfer;
using Blog.Application.Exceptions;
using Blog.Application.Queries;
using Blog.EfDataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Blog.Implementation.Queries
{
    public class EfGetOnePostQuery : IGetOnePostQuery
    {
        private readonly BlogContext _context;
        private readonly IMapper _mapper;

        public EfGetOnePostQuery(BlogContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public int Id => 13;

        public string Name => "Search One Post";

        public PostDto Execute(int search)
        {
            var post = _context.Posts.Include(x => x.Category).Include(x => x.Image).Include(x => x.Comments).FirstOrDefault(x => x.Id == search);

            if (post == null)
            {
                throw new EntityNotFoundException(search, typeof(PostDto));
            }

            //var response = _mapper.Map<PostDto>(post);

            var response = new PostDto
            {
                Id = post.Id,
                Title = post.Title,
                Description = post.Description,
                ImageId = post.ImageId,
                CategoryId = post.CategoryId,
                Comments = post.Comments.Where(x => x.PostId == post.Id).ToList()
            };

            return response;
        }
    }
}
