using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using library.Models;

namespace library.Controllers
{
    public class HomeController : Controller
    {
        BookContext db = new BookContext();
        public ActionResult Index()
        {
            var books = db.Books;
            ViewBag.Books = books;
            return View();
        }
        [HttpGet]
        public ActionResult  Buy(int id)
        {
            ViewBag.BookId = id;
            return View();
        }

        [HttpPost]
        public string Buy(PurchaseModel purchase)
        {
            purchase.Date=DateTime.Now;
            db.Purchases.Add(purchase);
            db.SaveChanges();
            return "Уважаемый " + purchase.Person + " книга успешно забронирована";

        }

        public string Sum() {
            {
                var a = Convert.ToInt32(Request.Params["a"]);
                var b = Convert.ToInt32(Request.Params["b"]);
                return "<h2>"+a + b+"</h2>";
            }
    }
        

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}