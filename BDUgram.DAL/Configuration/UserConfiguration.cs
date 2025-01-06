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
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasIndex(x => x.UserName)
                .IsUnique();
            builder.HasIndex(x => x.Email)
                .IsUnique();
            builder.Property(x => x.UserName)
                .IsRequired()
                .HasMaxLength(32);
            builder.Property(x => x.Email) 
                .IsRequired()
                .HasMaxLength (48);
            builder.Property(x => x.FullName)
                .IsRequired()
                .HasMaxLength(48);
            builder.Property(x => x.isMale)
                .IsRequired();


        }
    }
}
