using Blog.Application.DataTransfer;
using Blog.EfDataAccess;
using FluentValidation;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Blog.Implementation.Validators
{
    public class CreateCategoryValidator : AbstractValidator<CategoryDto>
    {
        public CreateCategoryValidator(BlogContext context)
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .MaximumLength(30)
                .Must(name => !context.Categories.Any(c => c.Name == name))
                .WithMessage("Category name must be unique.");
        }
    }
}
