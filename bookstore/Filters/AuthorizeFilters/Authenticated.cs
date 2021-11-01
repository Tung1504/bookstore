using bookstore.Helpers;
using bookstore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace bookstore.Filters.AuthorizeFilters
{
    public class Authenticated : ActionFilterAttribute, IActionFilter
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            User user = AuthUser.GetLogin();
            if (user == null)
            {
                filterContext.Result = new RedirectToRouteResult(
                    new System.Web.Routing.RouteValueDictionary(new
                    {
                        controller = "Auth",
                        action ="LoginOrSignup"
                    }
                ));
            }
        }
    }
}