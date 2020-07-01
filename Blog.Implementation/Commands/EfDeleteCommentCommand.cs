using Blog.Application.Commands;
using Blog.Application.DataTransfer;
using Blog.Application.Exceptions;
using Blog.EfDataAccess;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Implementation.Commands
{
    public class EfDeleteCommentCommand : IDeleteCommentCommand
    {
        private readonly BlogContext _context;

        public EfDeleteCommentCommand(BlogContext context)
        {
            _context = context;
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

            comment.IsDeleted = true;
            comment.DeletedAt = DateTime.UtcNow;
            comment.IsActive = false;

            _context.SaveChanges();
        }
    }
}
