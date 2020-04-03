using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using library.Models;

namespace library.Controllers
{
    public class HomeController : Controller
    {
        BookContext db = new BookContext();

        public ActionResult GetContext()
        {
            var browser = HttpContext.Request.Browser;
            var user = HttpContext.Request.UserAgent;
            var url = HttpContext.Request.RawUrl;
            var ip = HttpContext.Request.UserHostAddress;
            string referrer = HttpContext.Request.UrlReferrer == null ? "" : HttpContext.Request.UrlReferrer.AbsoluteUri;
            return Content("<p>Browser: " + browser + "</p><p>User-Agent: " + user + "</p><p>Url запроса: " + url +
                   "</p><p>Реферер: " + referrer + "</p><p>IP-адрес: " + ip + "</p>");
        }
        [Authorize]
        public ActionResult Index()
        {
            if (User.Identity.IsAuthenticated)
            {
                return Content(User.Identity.Name);
            }
            var books = db.Books;
            //ViewBag.Books = books;
            //Response.Cookies["id"].Value = "dsa";
            //Session["user"] = "tom";
            return View(books);
            //return Content(Request.Cookies["id"].Value+ Session["user"]); /*Content("View()")*/
        }
        //ассинхронный метод
        
        [HttpGet]
        public ActionResult Buy(int id)
        {
            ViewBag.BookId = id;
            var purchase = new PurchaseModel() {BookId = id};
            return View(purchase);
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
        [HttpGet]
        public ActionResult Create()
        {
            var books = db.Books;
            return View(books.First());
        }
        [HttpPost]
        public string Create(BookModel Book)
        {
            db.Books.Add(Book);
            db.SaveChanges();
            return "<p>Книга успешно добавлена<p>";
        }

        [Authorize(Roles = "admin")]
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