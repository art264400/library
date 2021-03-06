﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Web;
using System.Web.Mvc;
using library.Models;

namespace library.Controllers
{
    public class AdminController : Controller
    {
        private BookContext db = new BookContext();

        //    // GET: Admin
        public ActionResult Users()
        {
            var users = db.Users.Include(m => m.Role);
            return View(users.ToList());
        }

        public ActionResult Edit(int id)
        {
            SelectList Roles=new SelectList(db.Roles,"Id","Name");
            ViewData["roles"] = Roles;
            var user = db.Users.FirstOrDefault(m => m.Id == id);
            return View(user);
        }
        [HttpPost]
        public ActionResult Edit(UserModel user)
        {
            db.Entry(user).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Users");
        }

        //public ActionResult Users()
        //{
        //    return View();
        //}
    }
}
