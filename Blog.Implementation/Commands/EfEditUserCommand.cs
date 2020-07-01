using AutoMapper;
using Blog.Application.Commands;
using Blog.Application.DataTransfer;
using Blog.Application.Exceptions;
using Blog.EfDataAccess;
using Blog.Implementation.Validators;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Implementation.Commands
{
    public class EfEditUserCommand : IEditUserCommand
    {
        private readonly BlogContext _context;
        private readonly EditUserValidator _validator;
        private readonly IMapper _mapper;

        public EfEditUserCommand(BlogContext context, EditUserValidator validator, IMapper mapper)
        {
            _context = context;
            _validator = validator;
            _mapper = mapper;
        }

        public int Id => 11;

        public string Name => "Edit User";

        public void Execute(UserDto request)
        {
            var id = request.Id;

            var user = _context.Users.Find(id);

            if(user == null)
            {
                throw new EntityNotFoundException(id, typeof(UserDto));
            }

            _validator.ValidateAndThrow(request);

            _mapper.Map(request, user);

            _context.SaveChanges();
        }
    }
}
