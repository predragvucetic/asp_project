using Blog.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.EfDataAccess.Configurations
{
    public class ImageConfiguration : IEntityTypeConfiguration<Image>
    {
        public void Configure(EntityTypeBuilder<Image> builder)
        {
            builder.HasOne(i => i.Post).WithOne(p => p.Image).HasForeignKey<Post>(p => p.ImageId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
