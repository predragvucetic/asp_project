using Blog.Application.DataTransfer;
using Blog.EfDataAccess;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Blog.Implementation.Validators
{
    public class EditCategoryValidator : AbstractValidator<CategoryDto>
    {
        public EditCategoryValidator(BlogContext context)
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .MaximumLength(30)
                .Must((x, name) => !context.Categories.Any(c => c.Name == name && c.Id != x.Id))
                .WithMessage("Category name must be unique.");
        }
    }
}
