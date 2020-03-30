using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace library.Controllers
{
    public class libraryController : Controller
    {
        // GET: library
        public ActionResult Index(string param)
        {
            ViewData["param"]=param;
            ViewBag.param2 = param;
            return View();
        }

      
    }
}