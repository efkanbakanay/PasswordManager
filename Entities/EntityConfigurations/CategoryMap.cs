using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.EntityConfigurations
{
    public class CategoryMap : IEntityTypeConfiguration<Category>, IEntityConfig
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {

            builder.Property(s => s.CategoryName).IsRequired();
            builder.Property(x => x.CreatedAt).HasDefaultValue(DateTime.Now);
            builder.Property(s => s.IsActive).HasDefaultValue(1);
            builder.Property(s => s.IsDeleted).HasDefaultValue(0);


        }
    }
}
