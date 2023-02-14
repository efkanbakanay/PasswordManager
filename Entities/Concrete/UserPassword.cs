using Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Entities.Concrete
{
    public class UserPassword : IEntity
    {

        public int Id { get; set; }
        public int UserId { get; set; }
        public int? CategoryId { get; set; }
        public string RecordDefinition { get; set; }
        public string URL { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public User User { get; set; }
        public Category Category { get; set; }

        [NotMapped]
        public string CategoryName { get; set; }



    }
}
