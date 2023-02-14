using Entities.Concrete;
using Entities.Dtos;
using System.Collections.Generic;

namespace Web.Models
{
    public class PasswordViewModel
    {
        public List<UserPasswordCategoryDto> UserPasswordList { get; set; }
        public UserPassword UserPassword { get; set; }
        public List<Category> CategoryList { get; set; }
        public Category Category { get; set; }
        public int CategoryId { get; set; }
    }
}
