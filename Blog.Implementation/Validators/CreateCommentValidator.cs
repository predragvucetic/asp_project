using Blog.Application.DataTransfer;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Implementation.Validators
{
    public class CreateCommentValidator : AbstractValidator<CommentDto>
    {
        public CreateCommentValidator()
        {
            RuleFor(x => x.Content)
                .NotEmpty();
            RuleFor(x => x.PostId)
                .NotEmpty();
            //RuleFor(x => x.UserId)
            //    .NotEmpty();
        }
    }
}
