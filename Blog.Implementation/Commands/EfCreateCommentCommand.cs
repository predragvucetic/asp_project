using AutoMapper;
using Blog.Application;
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
    public class EfCreateCommentCommand : ICreateCommentCommand
    {
        private readonly BlogContext _context;
        private readonly CreateCommentValidator _validator;
        private readonly IMapper _mapper;
        private readonly IApplicationActor _actor;

        public EfCreateCommentCommand(BlogContext context, CreateCommentValidator validator, IMapper mapper, IApplicationActor actor)
        {
            _context = context;
            _validator = validator;
            _mapper = mapper;
            _actor = actor;
        }

        public int Id => 19;

        public string Name => "Create New Comment";

        public void Execute(CommentDto request)
        {
            _validator.ValidateAndThrow(request);

            _context.Comments.Include(x => x.User);

            var userId = _actor.Id;

            //var comment = _mapper.Map<Comment>(request);

            var comment = new Comment
            {
                Content = request.Content,
                PostId = request.PostId,
                UserId = userId
            };

            _context.Comments.Add(comment);

            _context.SaveChanges();
        }
    }
}
