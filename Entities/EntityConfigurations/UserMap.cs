using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.EntityConfigurations
{
    public class UserMap : IEntityTypeConfiguration<User>, IEntityConfig
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
           
            builder.Property(s => s.FullName).IsRequired().HasMaxLength(150);
            builder.HasIndex(y => y.Email).IsUnique();
            builder.Property(x => x.CreatedAt).HasDefaultValue(DateTime.Now);


        }
    }
}
