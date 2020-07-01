using AutoMapper;
using Blog.Application.Commands;
using Blog.Application.DataTransfer;
using Blog.Domain;
using Blog.EfDataAccess;
using Blog.Implementation.Validators;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Implementation.Commands
{
    public class EfCreatePostCommand : ICreatePostCommand
    {
        private readonly BlogContext _context;
        private readonly CreatePostValidator _validator;
        private readonly IMapper _mapper;

        public EfCreatePostCommand(BlogContext context, CreatePostValidator validator, IMapper mapper)
        {
            _context = context;
            _validator = validator;
            _mapper = mapper;
        }

        public int Id => 14;

        public string Name => "Create New Post";

        public void Execute(PostDto request)
        {
            _validator.ValidateAndThrow(request);

            var post = _mapper.Map<Post>(request);

            _context.Posts.Add(post);

            _context.SaveChanges();
        }
    }
}
