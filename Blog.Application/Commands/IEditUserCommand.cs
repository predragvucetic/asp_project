using Blog.Application.DataTransfer;
using Blog.Application.UseCases;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Application.Commands
{
    public interface IEditUserCommand : ICommand<UserDto>
    {
    }
}
