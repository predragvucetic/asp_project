using Blog.Application.Commands;
using Blog.Application.DataTransfer;
using Blog.Application.Exceptions;
using Blog.EfDataAccess;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Implementation.Commands
{
    public class EfDeletePostCommand : IDeletePostCommand
    {
        private readonly BlogContext _context;

        public EfDeletePostCommand(BlogContext context)
        {
            _context = context;
        }

        public int Id => 15;

        public string Name => "Delete Post";

        public void Execute(int request)
        {
            var post = _context.Posts.Find(request);

            if(post == null)
            {
                throw new EntityNotFoundException(request, typeof(PostDto));
            }

            post.IsDeleted = true;
            post.DeletedAt = DateTime.UtcNow;
            post.IsActive = false;

            _context.SaveChanges();
        }
    }
}
