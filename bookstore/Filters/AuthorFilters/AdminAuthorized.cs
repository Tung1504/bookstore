using bookstore.Helpers;
using bookstore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace bookstore.Filters.AuthorFilters
{
    public class AdminAuthorized : ActionFilterAttribute, IActionFilter
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            User user = AuthUser.GetLogin();
            if (user == null || user.role.ToString() != "Admin")
            {
                filterContext.Result = new RedirectToRouteResult(
                    new System.Web.Routing.RouteValueDictionary(new
                    {
                        controller = "Auth",
                        action = "LoginOrSignUp",
                        area = "",
                    }
                ));
            }

        }
    }
}