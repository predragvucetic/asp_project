using Blog.Application.DataTransfer;
using Blog.EfDataAccess;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Blog.Implementation.Validators
{
    public class CreatePostValidator : AbstractValidator<PostDto>
    {
        public CreatePostValidator(BlogContext context)
        {
            RuleFor(x => x.Title)
                .NotEmpty()
                .MaximumLength(50)
                .Must(title => !context.Posts.Any(p => p.Title == title))
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
