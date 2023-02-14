using System;
using System.Collections.Generic;
using System.Text;
using Entities.Concrete;
using Entities.Dtos;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class CategoryDtoValidator : AbstractValidator<CategoryDto>
    {
        public CategoryDtoValidator()
        {
            RuleFor(p => p.CategoryName).NotEmpty().WithMessage("Kategori Alanı Zorunludur!");

        }

       
    }
}
