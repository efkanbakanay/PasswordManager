using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class Category : IEntity
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string CategoryName { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime CreatedAt { get; set; }

        public User User { get; set; }
        public ICollection<UserPassword> UserPasswords { get; set;}
        

    }
}
