using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Security;
using library.Models;

namespace library.Controllers
{
    public class AccountController : Controller
    {
        BookContext db=new BookContext();
        // GET: Account
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(RegisterModel model)
        {

            if (ModelState.IsValid)
            {
                UserModel user = null;
                user = db.Users.FirstOrDefault(u => u.Login == model.Login);
                if (user == null)
                {
                    db.Users.Add(new UserModel()
                    {
                        Email = model.Email,
                        Login = model.Login,
                        Name = model.Name,
                        Password = model.Password,
                        Surname = model.Surname,
                        RoleId = 2
                    });
                    db.SaveChanges();
                    user = db.Users.FirstOrDefault(u => u.Login == model.Login && u.Password == model.Password);
                    if (user != null)
                    {
                        FormsAuthentication.SetAuthCookie(model.Login, true);
                        return RedirectToAction("Index", "Home");
                    }
                }
                else
                {
                    ModelState.AddModelError(null, "Пользователь уже сущесвтует");
                }
            }

            return View(model);
        }

        public ActionResult Login()
        {
            return View();
        }
        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                var user = db.Users.FirstOrDefault(n => n.Login == model.Login && n.Password == model.Password);
                if (user != null)
                {
                    FormsAuthentication.SetAuthCookie(model.Login,true);
                    return RedirectToAction("Index", "Home");
                }  
            }
            else
            {
                ModelState.AddModelError(null,"Не привильно введен логин или пароль");
            }
            return View(model);
        }

        public ActionResult Logout()
        {
            return View("Logout");
        }
        [HttpPost]
        public ActionResult Logout(LoginModel model)
        {
            return View("Logout");
        }
        //public void Execute(RequestContext requestContext)
        //{
        //    var cookies = requestContext.HttpContext.Request.Cookies;
        //    var ip = requestContext.HttpContext.Request.UserHostAddress;
        //    var response = requestContext.HttpContext.Response;
        //    response.Write("<h2>Ваш ip адрес "+ip+ "</h2>");
        //}


    }
}