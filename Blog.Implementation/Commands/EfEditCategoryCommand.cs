using AutoMapper;
using Blog.Application.Commands;
using Blog.Application.DataTransfer;
using Blog.Application.Exceptions;
using Blog.Domain;
using Blog.EfDataAccess;
using Blog.Implementation.Validators;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Implementation.Commands
{
    public class EfEditCategoryCommand : IEditCategoryCommand
    {
        private readonly BlogContext _context;
        private readonly EditCategoryValidator _validator;
        private readonly IMapper _mapper;

        public EfEditCategoryCommand(BlogContext context, EditCategoryValidator validator, IMapper mapper)
        {
            _context = context;
            _validator = validator;
            _mapper = mapper;
        }

        public int Id => 7;

        public string Name => "Edit Category";

        public void Execute(CategoryDto request)
        {
            var id = request.Id;

            var category = _context.Categories.Find(id);

            if (category == null)
            {
                throw new EntityNotFoundException(id, typeof(CategoryDto));
            }

            _validator.ValidateAndThrow(request);

            _mapper.Map(request, category);

            _context.SaveChanges();
        }
    }
}
