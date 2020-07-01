using AutoMapper;
using Blog.Application.Commands;
using Blog.Application.DataTransfer;
using Blog.Application.Email;
using Blog.Domain;
using Blog.EfDataAccess;
using Blog.Implementation.Validators;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace Blog.Implementation.Commands
{
    public class EfRegisterUserCommand : IRegisterUserCommand
    {
        private readonly BlogContext _context;
        private readonly RegisterUserValidator _validator;
        private readonly IEmailSender _sender;
        private readonly IMapper _mapper;

        public EfRegisterUserCommand(BlogContext context, RegisterUserValidator validator, IEmailSender sender, IMapper mapper)
        {
            _context = context;
            _validator = validator;
            _sender = sender;
            _mapper = mapper;
        }

        public int Id => 4;

        public string Name => "User Registration";

        public void Execute(RegisterUserDto request)
        {
            _validator.ValidateAndThrow(request);

            _context.Users.Include(x => x.UserUseCases);

            var user = _mapper.Map<User>(request);

            _context.Users.Add(user);

            _context.SaveChanges();

            // --- OVAJ DEO ---
            int[] allowedUseCases = new int[] { 3, 6, 12, 13, 17, 18, 19, 20, 21 };

            //var id = 1;

            foreach (var auc in allowedUseCases)
            {
                _context.UserUseCase.Add(new UserUseCase
                {
                    //Id = id,
                    UserId = user.Id,
                    UseCaseId = auc
                });
                //id++;
            }

            _context.SaveChanges();

            _sender.Send(new SendEmailDto
            {
                Subject = "Registration",
                Content = "<h1>Successffully Registration</h1>",
                SendTo = request.Email
            });
        }
    }
}
