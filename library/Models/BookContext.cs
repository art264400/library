using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace library.Models
{
    public class BookContext:DbContext
    {
        public DbSet<BookModel> Books { get; set; }
        public DbSet<PurchaseModel> Purchases { get; set; }
    }

    public class BookDbInit : DropCreateDatabaseAlways<BookContext>
    {
        protected override void Seed(BookContext db)
        {
            db.Books.Add(new BookModel() {Name = "Война и Мир", Description = "Написал Лев Толстой"});
            base.Seed(db);
        }
    }
}