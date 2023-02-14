using System;
using System.Collections.Generic;
using System.Text;
using Entities.Concrete;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class UserPasswordValidator : AbstractValidator<UserPassword>
    {
        public UserPasswordValidator()
        {
            RuleFor(p => p.RecordDefinition).NotEmpty().WithMessage("Kayıt Tanımı Zorunludur!");
            RuleFor(p => p.URL).NotEmpty().WithMessage("URL Alanı Zorunludur!");
            RuleFor(p => p.UserName).NotEmpty().WithMessage("Kullanıcı Adı Zorunludur!");
            RuleFor(p => p.Password).NotEmpty().WithMessage("Parola Alanı Zorunludur!");
            RuleFor(p => p.CategoryId).GreaterThan(0).WithMessage("Kategori Seçilmesi Zorunludur!");
            RuleFor(p => p.CategoryId).NotEmpty().WithMessage("Kategori Seçilmesi Zorunludur!");
       

        }

       
    }
}
