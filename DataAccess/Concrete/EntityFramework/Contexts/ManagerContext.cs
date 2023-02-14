using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Entities.Concrete;
using System.Reflection;
using System.Linq;
using Entities;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.Extensions.Configuration;
using Entities.EntityConfigurations;

namespace DataAccess.Concrete.EntityFramework.Contexts
{


    public class ManagerContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=.;Database=PasswordManager;Trusted_Connection=true");
            
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<UserPassword> UserPasswords { get; set; }




        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {


            var typesToRegister = AppDomain.CurrentDomain.GetAssemblies().SelectMany(x => x.GetTypes())
               .Where(x => typeof(IEntityConfig).IsAssignableFrom(x) && !x.IsAbstract).ToList();


            foreach (var type in typesToRegister)
            {
                dynamic configurationInstance = Activator.CreateInstance(type);
                modelBuilder.ApplyConfiguration(configurationInstance);
            }



            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.NoAction;
            }


        }

    }
}
