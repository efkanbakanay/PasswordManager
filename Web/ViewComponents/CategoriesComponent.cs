using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;
using Web.Helper;
using Web.Models;

namespace Web.ViewComponents
{
    public class CategoriesComponent : ViewComponent
    {

        private ICategoryService _categoryService;

        public CategoriesComponent(ICategoryService categoryService)
        {
                _categoryService= categoryService;
        }

        public IViewComponentResult Invoke(int? CategoryId)
        {
            var userInfo = HttpContext.Session.Get<User>("UserInfoSession");
            var categories = _categoryService.GetAll(userInfo.Id).Data;

            return View(new PasswordViewModel { CategoryList = categories, CategoryId = CategoryId.GetValueOrDefault() });
        }
    }
}
