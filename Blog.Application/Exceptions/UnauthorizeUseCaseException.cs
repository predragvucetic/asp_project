using Blog.Application.UseCases;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Application.Exceptions
{
    public class UnauthorizeUseCaseException : Exception
    {
        public UnauthorizeUseCaseException(IUseCase useCase, IApplicationActor actor)
            :base($"Actor with an id of {actor.Id} - {actor.Identity} tried to execute {useCase.Name}.")
        {

        }
    }
}
