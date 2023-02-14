using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Routing;
using System;

namespace Web.Helper
{
    public class LoginFilter : Attribute, IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext context)
        {
           
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            var session = context.HttpContext.Session.Get<User>("UserInfoSession");

            if (session != null)
            {
                context.HttpContext.Session.SetString("UserFullnameS", session.FullName);
                context.HttpContext.Session.SetString("UserEmailS", session.Email);
            }
            else
            {
                context.Result = new RedirectToRouteResult(
             new RouteValueDictionary { { "controller", "Auth" }, { "action", "Login" } });
            }

          


        }
    }
}
