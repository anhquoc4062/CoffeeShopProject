using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoffeeShopProject.Common;
using CoffeeShopProject.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Routing;

namespace CoffeeShopProject.Controllers
{
    public class BaseController : Controller
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if(HttpContext.Session.GetString("ACCID_SESSION") == null)
            {
                context.Result = new RedirectToRouteResult(new 
                    RouteValueDictionary(new { controller = "Login", action = "Index" }));
            }
            else
            {
                if(HttpContext.Session.GetString("CREDENTITY_SESSION") == "kh")
                {
                    context.Result = new RedirectToRouteResult(new
                    RouteValueDictionary(new { controller = "TrangChu", action = "Index" }));
                }
            }
            base.OnActionExecuting(context);
        }
    }
}