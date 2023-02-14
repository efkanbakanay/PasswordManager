using Business.Abstract;
using Business.ValidationRules.FluentValidation;
using Entities.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using Web.Helper;
using Web.Models;

namespace Web.Controllers
{
    [LoginFilter]
    public class MyPasswordController : Controller
    {
        IUserPasswordService _userPasswordService;
        public MyPasswordController(IUserPasswordService userPasswordService)
        {
            _userPasswordService = userPasswordService;
        }


        public IActionResult Index()
        {

            var userPasswordList = _userPasswordService.GetAllIncCategory(getUserInfo().Id).Data;


            return View(new PasswordViewModel {  UserPasswordList = userPasswordList });
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(UserPassword request)
         {

            request.UserId = getUserInfo().Id;

            UserPasswordValidator validator = new UserPasswordValidator();
            ValidationResult result = validator.Validate(request);

            if (!result.IsValid)
            {

                foreach (ValidationFailure failer in result.Errors)
                {
                    ModelState.AddModelError(failer.PropertyName, failer.ErrorMessage);
                }

                return View(request);
            }


            var data = _userPasswordService.Add(request);

            if (!data.Success)
            {
                TempData["Message"] = data.Message;
                return View();
            }



            TempData["Success"] = data.Message;

            return RedirectToAction("Index");
        }

        public IActionResult Edit(int Id)
        {
            var result = _userPasswordService.GetById(Id);
            if (!result.Success)
            {
                TempData["Message"] = result.Message;
                return View();
            }

            return View(result.Data);
        }

        [HttpPost]
        public IActionResult Edit(UserPassword request)
        {

            UserPasswordValidator validator = new UserPasswordValidator();
            ValidationResult result = validator.Validate(request);

            if (!result.IsValid)
            {

                foreach (ValidationFailure failer in result.Errors)
                {
                    ModelState.AddModelError(failer.PropertyName, failer.ErrorMessage);
                }

                return View(request);
            }

            request.UpdatedAt = DateTime.Now;
            request.IsActive = true;
            var res = _userPasswordService.Update(request);
            if (!res.Success)
            {
                TempData["Message"] = res.Message;
                return RedirectToAction("Index");
            }


            TempData["Success"] = res.Message;

            return RedirectToAction("Index");
        }

        public JsonResult View(int Id)
        {


            var result = _userPasswordService.GetByIdCategoy(Id);

            if (!result.Success)
                return Json(new { success = result.Success, message = result.Message });


            return Json(result.Data);


        }


        public JsonResult Delete(int Id)
        {

            var result = _userPasswordService.GetById(Id);

            if (!result.Success)
                return Json(new { success = result.Success, message = result.Message });


            _userPasswordService.Delete(result.Data);

            return Json(new { success = true, message = "Silme işlemi başarılı" });


        }


        [HttpPost]
        public IActionResult GetPasswordList()
        {
            try
            {
                var draw = Request.Form["draw"].FirstOrDefault();
                var start = Request.Form["start"].FirstOrDefault();
                var length = Request.Form["length"].FirstOrDefault();
                var sortColumn = Request.Form["columns[" + Request.Form["order[0][column]"].FirstOrDefault() + "][name]"].FirstOrDefault();
                var sortColumnDirection = Request.Form["order[0][dir]"].FirstOrDefault();
                var searchValue = Request.Form["search[value]"].FirstOrDefault();
                int pageSize = length != null ? Convert.ToInt32(length) : 0;
                int skip = start != null ? Convert.ToInt32(start) : 0;
                int recordsTotal = 0;
                var courseData = _userPasswordService.GetPasswordList(searchValue, pageSize, skip, sortColumn, sortColumnDirection, getUserInfo().Id).Data;
                recordsTotal = _userPasswordService.GetPasswordCount(searchValue, pageSize, skip, sortColumn, sortColumnDirection, getUserInfo().Id).Data;

                var jsonData = new { draw = draw, recordsFiltered = recordsTotal, recordsTotal = recordsTotal, data = courseData };
                return Ok(jsonData);
            }
            catch (Exception)
            {
                throw;
            }
        }



        public User getUserInfo()
        {
            return HttpContext.Session.Get<User>("UserInfoSession");
        }
    }
}
