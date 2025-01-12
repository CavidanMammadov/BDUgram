using BDugram.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BDUgram.DAL.Configuration
{
    public class BlogConfiguration : IEntityTypeConfiguration<Blog>
    {
        public void Configure(EntityTypeBuilder<Blog> builder)
        {
            builder
                .HasOne(x => x.Publisher)
                .WithMany(x => x.Blogs)
                .HasForeignKey(x => x.PublisherId);
            builder
                .HasOne(x => x.Category)
                .WithMany(x => x.Blogs)
                .HasForeignKey(x => x.CategoryId);
            builder.Property(x => x.Title)
                .IsRequired()
                .HasMaxLength(32);
            builder.Property(x => x.Content)
                .IsRequired()
                .HasMaxLength(48);
           
        }
    }
}
