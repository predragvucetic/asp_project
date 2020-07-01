using Blog.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.EfDataAccess.Configurations
{
    public class UserUseCaseConfiguration : IEntityTypeConfiguration<UserUseCase>
    {
        public void Configure(EntityTypeBuilder<UserUseCase> builder)
        {
            builder.HasKey(x => new { x.UserId, x.UseCaseId });
            builder.HasOne<User>(x => x.User).WithMany(z => z.UserUseCases).OnDelete(DeleteBehavior.Restrict);
            builder.HasOne<UseCase>(x => x.UseCase).WithMany(z => z.UserUseCases).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
