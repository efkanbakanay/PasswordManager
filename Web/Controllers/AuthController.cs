using Business.Abstract;
using Business.ValidationRules.FluentValidation;
using Core.Utilities.Results;
using Entities.Dtos;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Newtonsoft.Json;
using System;
using Web.Helper;

namespace Web.Controllers
{
    public class AuthController : Controller
    {

        private IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(UserForLoginDto request)
        {

            UserForLoginDtoValidator validator = new UserForLoginDtoValidator();
            ValidationResult result = validator.Validate(request);

            if (!result.IsValid)
            {

                foreach (ValidationFailure failer in result.Errors)
                {
                    ModelState.AddModelError(failer.PropertyName, failer.ErrorMessage);
                }

                return View();
            }

            var userToLogin = _authService.Login(request);
            if (!userToLogin.Success)
            {
                TempData["Message"] = userToLogin.Message;
                return View();
            }
            else
            {
                userToLogin.Data.PasswordSalt = null;
                userToLogin.Data.PasswordHash = null;
                HttpContext.Session.Set("UserInfoSession", userToLogin.Data);
            }
              



            return RedirectToAction("Index", "MyPassword");
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(UserForRegisterDto userForRegisterDto)
        {

            UserForRegisterDtoValidator validator = new UserForRegisterDtoValidator();
            ValidationResult result = validator.Validate(userForRegisterDto);

            if (!result.IsValid)
            {

                foreach (ValidationFailure failer in result.Errors)
                {
                    ModelState.AddModelError(failer.PropertyName, failer.ErrorMessage);
                }

                return View(userForRegisterDto);
            }


            var userExists = _authService.UserExists(userForRegisterDto.Email);
            if (!userExists.Success)
            {
                TempData["Message"] = userExists.Message;
                return View(userForRegisterDto);
            }

            var registerResult = _authService.Register(userForRegisterDto, userForRegisterDto.Password);

            if (!registerResult.Success)
            {
                TempData["Message"] = registerResult.Message;
                return View(userForRegisterDto);
            }


            TempData["Success"] = registerResult.Message;
            return RedirectToAction("Login");
           
        }



        public IActionResult LogOut()
        {
            HttpContext.Session.Remove("UserInfoSession");
            HttpContext.Session.Clear();
            return Redirect("Login");
        }


    


    }
}
