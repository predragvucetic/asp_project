using Blog.Application;
using Blog.Application.Commands;
using Blog.Application.DataTransfer;
using Blog.Application.Exceptions;
using Blog.EfDataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace Blog.Implementation.Commands
{
    public class EfDeleteCommentCommand : IDeleteCommentCommand
    {
        private readonly BlogContext _context;
        private readonly IApplicationActor _actor;

        public EfDeleteCommentCommand(BlogContext context, IApplicationActor actor)
        {
            _context = context;
            _actor = actor;
        }

        public int Id => 21;

        public string Name => "Delete Comment";

        public void Execute(int request)
        {
            var comment = _context.Comments.Find(request);

            if(comment == null)
            {
                throw new EntityNotFoundException(request, typeof(CommentDto));
            }

            var userId = comment.UserId;

            if ((userId != _actor.Id) && (_actor.Id != 5))
            {
                throw new Exception();
            }

            comment.IsDeleted = true;
            comment.DeletedAt = DateTime.UtcNow;
            comment.IsActive = false;

            _context.SaveChanges();
        }
    }
}
