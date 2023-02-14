using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework.Contexts;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EFCategoryDal : EfEntityRepositoryBase<Category, ManagerContext>, ICategoryDal
    {
        public Category AddAndReturn(Category category)
        {

            using (ManagerContext context = new ManagerContext())
            {
                var addedEntity = context.Entry(category);
                addedEntity.State = EntityState.Added;
                context.SaveChanges();

                return category;

            }


        }
    }
}
