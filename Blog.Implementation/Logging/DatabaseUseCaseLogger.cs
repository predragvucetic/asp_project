using Blog.Application;
using Blog.Application.UseCases;
using Blog.Domain;
using Blog.EfDataAccess;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Implementation.Logging
{
    public class DatabaseUseCaseLogger : IUseCaseLogger
    {
        private readonly BlogContext _context;

        public DatabaseUseCaseLogger(BlogContext context)
        {
            _context = context;
        }

        public void Log(IUseCase useCase, IApplicationActor actor, object data)
        {
            _context.UseCaseLogs.Add(new UseCaseLog
            {
                Date = DateTime.UtcNow,
                UseCaseName = useCase.Name,
                Data = JsonConvert.SerializeObject(data),
                Actor = actor.Identity,
            });

            _context.SaveChanges();
        }
    }
}
