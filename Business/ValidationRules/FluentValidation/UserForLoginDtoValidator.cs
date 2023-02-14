using System;
using System.Collections.Generic;
using System.Text;
using Entities.Concrete;
using Entities.Dtos;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class UserForLoginDtoValidator : AbstractValidator<UserForLoginDto>
    {
        public UserForLoginDtoValidator()
        {
            RuleFor(p => p.Email).NotEmpty().WithMessage("Email Alanı Zorunludur!");
            RuleFor(p => p.Password).NotEmpty().WithMessage("Parola Alanı Zorunludur!");

        }

       
    }
}
