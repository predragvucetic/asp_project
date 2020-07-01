using Blog.Application.DataTransfer;
using Blog.EfDataAccess;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Blog.Implementation.Validators
{
    public class EditCommentValidator : AbstractValidator<CommentDto>
    {
        public EditCommentValidator(BlogContext context)
        {
            RuleFor(x => x.Content)
                .NotEmpty();
            RuleFor(x => x.PostId)
                .NotEmpty()
                .Must((x, postId) => !context.Comments.Any(c => c.PostId != postId))
                .WithMessage(x => $"Id of post must be {x.PostId}.");
            RuleFor(x => x.UserId)
                .NotEmpty()
                .Must((x, userId) => !context.Comments.Any(c => c.UserId != userId))
                .WithMessage(x => $"Id of user must be {x.UserId}.");
        }
    }
}
