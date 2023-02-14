using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Collections.Generic;
using System.Linq;
using System;
using Entities.Dtos;
using Business.ValidationRules.FluentValidation;
using FluentValidation.Results;
using Business.Abstract;
using Entities.Concrete;
using Web.Helper;

namespace Web.Controllers
{
    public class CategoryController : Controller
    {

        ICategoryService _categoryService;
        public CategoryController(ICategoryService categoryService)
        {
            _categoryService= categoryService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
       

        public JsonResult Create(Category request)
        {
            var userInfo = HttpContext.Session.Get<User>("UserInfoSession");
            request.UserId = userInfo.Id;

            CategoryValidator validator = new CategoryValidator();
            ValidationResult result = validator.Validate(request);

            if (!result.IsValid)
                return Json(new { success = false, message = result.Errors[0].ErrorMessage });


            var res = _categoryService.AddAndReturn(request);
            

            if (!res.Success)
                return Json(new { success = res.Success, message = res.Message });


            return Json(new { success = res.Success, message = res.Message, data = res.Data });


        }
    }
}
