using Blog.Application.DataTransfer;
using Blog.EfDataAccess;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Blog.Implementation.Validators
{
    public class EditPostValidator : AbstractValidator<PostDto>
    {
        public EditPostValidator(BlogContext context)
        {
            RuleFor(x => x.Title)
                .NotEmpty()
                .MaximumLength(50)
                .Must((x, title) => !context.Posts.Any(p => p.Title == title && p.Id != x.Id))
                .WithMessage("Post title must be unique.");
            RuleFor(x => x.Description)
                .NotEmpty();
            RuleFor(x => x.CategoryId)
                .NotEmpty();
            RuleFor(x => x.ImageId)
                .NotEmpty();
        }
    }
}
