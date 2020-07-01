using AutoMapper;
using Blog.Application.Commands;
using Blog.Application.DataTransfer;
using Blog.Application.Exceptions;
using Blog.EfDataAccess;
using Blog.Implementation.Validators;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Implementation.Commands
{
    public class EfEditPostCommand : IEditPostCommand
    {
        private readonly BlogContext _context;
        private readonly EditPostValidator _validator;
        private readonly IMapper _mapper;

        public EfEditPostCommand(BlogContext context, EditPostValidator validator, IMapper mapper)
        {
            _context = context;
            _validator = validator;
            _mapper = mapper;
        }

        public int Id => 16;

        public string Name => "Edit Post";

        public void Execute(PostDto request)
        {
            var id = request.Id;

            var post = _context.Posts.Find(id);

            if(post == null)
            {
                throw new EntityNotFoundException(id, typeof(PostDto));
            }

            _validator.ValidateAndThrow(request);

            _mapper.Map(request, post);

            _context.SaveChanges();
        }
    }
}
