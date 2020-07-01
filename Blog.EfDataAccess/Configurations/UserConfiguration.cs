using Blog.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.EfDataAccess.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.Property(x => x.FirstName).HasMaxLength(20).IsRequired();

            builder.Property(x => x.LastName).HasMaxLength(20).IsRequired();

            builder.Property(x => x.Email).IsRequired();
            builder.HasIndex(x => x.Email).IsUnique();

            builder.HasAlternateKey(x => x.Username);
            builder.Property(x => x.Username).HasMaxLength(30).IsRequired();

            builder.HasMany(x => x.Comments).WithOne(comment => comment.User).HasForeignKey(comment => comment.UserId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
