﻿using Blog.Application.Exceptions;
using Blog.Application.UseCases;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Blog.Application
{
    public class UseCaseExecutor
    {
        private readonly IApplicationActor _actor;
        private readonly IUseCaseLogger _logger;

        public UseCaseExecutor(IApplicationActor actor, IUseCaseLogger logger)
        {
            _actor = actor;
            _logger = logger;
        }

        public void ExecuteCommand<TRequest>(ICommand<TRequest> command, TRequest request)
        {
            _logger.Log(command, _actor, request);

            if (!_actor.AllowedUseCases.Contains(command.Id))
            {
                throw new UnauthorizeUseCaseException(command, _actor);
            }

            command.Execute(request);
        }

        public TResult ExecuteQuery<TSearch, TResult>(IQuery<TSearch, TResult> query, TSearch search)
        {
            _logger.Log(query, _actor, search);

            if (!_actor.AllowedUseCases.Contains(query.Id))
            {
                throw new UnauthorizeUseCaseException(query, _actor);
            }

            return query.Execute(search);
        }
    }
}
