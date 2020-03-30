using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using library.Models;

namespace library.Controllers
{
    public class AccountController : IController
    {
        // GET: Account
        //public ActionResult Login()
        //{
        //    var model = new LoginModel();
        //    return View(model);
        //}

        public void Execute(RequestContext requestContext)
        {
            var cookies = requestContext.HttpContext.Request.Cookies;
            var ip = requestContext.HttpContext.Request.UserHostAddress;
            var response = requestContext.HttpContext.Response;
            response.Write("<h2>Ваш ip адрес "+ip+ "</h2>");
           
        }
    }
}