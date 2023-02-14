using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.EntityConfigurations
{
    public class UserPasswordMap : IEntityTypeConfiguration<UserPassword>, IEntityConfig
    {
        public void Configure(EntityTypeBuilder<UserPassword> builder)
        {

            builder.Property(s => s.CategoryId).IsRequired();
            builder.Property(s => s.RecordDefinition).IsRequired();
            builder.Property(s => s.URL).IsRequired();
            builder.Property(s => s.UserName).IsRequired();
            builder.Property(s => s.Password).IsRequired();
            builder.Property(s => s.IsActive).HasDefaultValue(1);
            builder.Property(s => s.IsDeleted).HasDefaultValue(0);
            builder.Property(x => x.CreatedAt).HasDefaultValue(DateTime.Now);


        }
    }
}
