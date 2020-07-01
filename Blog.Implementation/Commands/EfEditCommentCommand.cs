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
    public class EfEditCommentCommand : IEditCommentCommand
    {
        private readonly BlogContext _context;
        private readonly EditCommentValidator _validator;
        private readonly IMapper _mapper;

        public EfEditCommentCommand(BlogContext context, EditCommentValidator validator, IMapper mapper)
        {
            _context = context;
            _validator = validator;
            _mapper = mapper;
        }

        public int Id => 20;

        public string Name => "Edit Comment";

        public void Execute(CommentDto request)
        {
            var id = request.Id;

            var comment = _context.Comments.Find(id);

            if(comment == null)
            {
                throw new EntityNotFoundException(id, typeof(CommentDto));
            }

            _validator.ValidateAndThrow(request);

            _mapper.Map(request, comment);

            _context.SaveChanges();
        }
    }
}
