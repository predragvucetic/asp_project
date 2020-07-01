using Blog.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.EfDataAccess.Configurations
{
    public class PostConfiguration : IEntityTypeConfiguration<Post>
    {
        public void Configure(EntityTypeBuilder<Post> builder)
        {
            builder.Property(p => p.Title).HasMaxLength(50).IsRequired();
            builder.HasIndex(p => p.Title).IsUnique();
            builder.Property(p => p.Description).IsRequired();
            //builder.HasOne(p => p.Image).WithOne(i => i.Post).HasForeignKey<Image>(i => i.Id).OnDelete(DeleteBehavior.Restrict);
            builder.HasMany(p => p.Comments).WithOne(comment => comment.Post).HasForeignKey(comment => comment.PostId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}