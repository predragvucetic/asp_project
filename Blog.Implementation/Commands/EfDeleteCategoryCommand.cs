using Blog.Application.Commands;
using Blog.Application.Exceptions;
using Blog.Domain;
using Blog.EfDataAccess;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Implementation.Commands
{
    public class EfDeleteCategoryCommand : IDeleteCategoryCommand
    {
        private readonly BlogContext _context;

        public EfDeleteCategoryCommand(BlogContext context)
        {
            _context = context;
        }

        public int Id => 2;

        public string Name => "Delete Category Using EF";

        public void Execute(int request)
        {
            var category = _context.Categories.Find(request);

            if(category == null)
            {
                throw new EntityNotFoundException(request, typeof(Category));
            }

            category.IsDeleted = true;
            category.DeletedAt = DateTime.UtcNow;
            category.IsActive = false;

            _context.SaveChanges();
        }
    }
}
