using Blog.Api.Core.Actors;
using Blog.Application;
using Blog.Application.Commands;
using Blog.Application.Queries;
using Blog.Implementation.Commands;
using Blog.Implementation.Queries;
using Blog.Implementation.Validators;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.Api.Core
{
    public static class ContainerExtensions
    {
        public static void AddUseCases(this IServiceCollection services)
        {
            services.AddTransient<ICreateCategoryCommand, EfCreateCategoryCommand>();
            services.AddTransient<IEditCategoryCommand, EfEditCategoryCommand>();
            services.AddTransient<IDeleteCategoryCommand, EfDeleteCategoryCommand>();
            services.AddTransient<IGetCategoryQuery, EfGetCategoryQuery>();
            services.AddTransient<IGetOneCategoryQuery, EfGetOneCategoryQuery>();

            services.AddTransient<IGetUsersQuery, EfGetUsersQuery>();
            services.AddTransient<IGetOneUserQuery, EfGetOneUserQuery>();
            services.AddTransient<IRegisterUserCommand, EfRegisterUserCommand>();
            services.AddTransient<IEditUserCommand, EfEditUserCommand>();
            services.AddTransient<IDeleteUserCommand, EfDeleteUserCommand>();

            services.AddTransient<IGetPostsQuery, EfGetPostsQuery>();
            services.AddTransient<IGetOnePostQuery, EfGetOnePostQuery>();
            services.AddTransient<ICreatePostCommand, EfCreatePostCommand>();
            services.AddTransient<IEditPostCommand, EfEditPostCommand>();
            services.AddTransient<IDeletePostCommand, EfDeletePostCommand>();

            services.AddTransient<IGetCommentsQuery, EfGetCommentsQuery>();
            services.AddTransient<IGetOneCommentQuery, EfGetOneCommentQuery>();
            services.AddTransient<ICreateCommentCommand, EfCreateCommentCommand>();
            services.AddTransient<IEditCommentCommand, EfEditCommentCommand>();
            services.AddTransient<IDeleteCommentCommand, EfDeleteCommentCommand>();

            services.AddTransient<CreateCategoryValidator>();
            services.AddTransient<EditCategoryValidator>();
            services.AddTransient<RegisterUserValidator>();
            services.AddTransient<EditUserValidator>();
            services.AddTransient<CreatePostValidator>();
            services.AddTransient<EditPostValidator>();
            services.AddTransient<CreateCommentValidator>();
            services.AddTransient<EditCommentValidator>();
        }

        public static void AddApplicationActor(this IServiceCollection services)
        {
            services.AddTransient<IApplicationActor>(x =>
            {
                var accessor = x.GetService<IHttpContextAccessor>();

                var user = accessor.HttpContext.User;

                if (user.FindFirst("ActorData") == null)
                {
                    return new AnonymousActor();
                }

                var actorString = user.FindFirst("ActorData").Value;

                var actor = JsonConvert.DeserializeObject<JwtActor>(actorString);

                return actor;
            });
        }
    }
}
