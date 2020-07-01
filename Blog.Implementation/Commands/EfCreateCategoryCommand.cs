using AutoMapper;
using Blog.Application.Commands;
using Blog.Application.DataTransfer;
using Blog.Domain;
using Blog.EfDataAccess;
using Blog.Implementation.Validators;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Implementation.Commands
{
    public class EfCreateCategoryCommand : ICreateCategoryCommand
    {
        private readonly BlogContext _context;
        private readonly CreateCategoryValidator _validator;
        private readonly IMapper _mapper;

        public EfCreateCategoryCommand(BlogContext context, CreateCategoryValidator validator, IMapper mapper)
        {
            _context = context;
            _validator = validator;
            _mapper = mapper;
        }

        public int Id => 1;

        public string Name => "Create New Category Using EF";

        public void Execute(CategoryDto request)
        {
            _validator.ValidateAndThrow(request);

            var category = _mapper.Map<Category>(request);

            _context.Categories.Add(category);

            _context.SaveChanges();
        }
    }
}
