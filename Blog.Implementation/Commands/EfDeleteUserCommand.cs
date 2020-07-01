using Blog.Application.Commands;
using Blog.Application.DataTransfer;
using Blog.Application.Exceptions;
using Blog.EfDataAccess;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Implementation.Commands
{
    public class EfDeleteUserCommand : IDeleteUserCommand
    {
        private readonly BlogContext _context;

        public EfDeleteUserCommand(BlogContext context)
        {
            _context = context;
        }

        public int Id => 10;

        public string Name => "Delete User";

        public void Execute(int request)
        {
            var user = _context.Users.Find(request);

            if(user == null)
            {
                throw new EntityNotFoundException(request, typeof(UserDto));
            }

            user.IsDeleted = true;
            user.DeletedAt = DateTime.UtcNow;
            user.IsActive = false;

            _context.SaveChanges();
        }
    }
}
