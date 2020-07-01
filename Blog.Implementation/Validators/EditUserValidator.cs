using Blog.Application.DataTransfer;
using Blog.EfDataAccess;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Blog.Implementation.Validators
{
    public class EditUserValidator : AbstractValidator<UserDto>
    {
        public EditUserValidator(BlogContext context)
        {
            RuleFor(x => x.FirstName)
                .NotEmpty()
                .MaximumLength(20);
            RuleFor(x => x.LastName)
                .NotEmpty()
                .MaximumLength(20);
            RuleFor(x => x.Email)
                .NotEmpty()
                .EmailAddress();
            RuleFor(x => x.Username)
                .NotEmpty()
                .MaximumLength(20)
                .Must((x, username) => !context.Users.Any(u => u.Username == username && u.Id != x.Id))
                .WithMessage("Username is already taken.");
            RuleFor(x => x.Password)
                .NotEmpty()
                .MinimumLength(6);
        }
    }
}
