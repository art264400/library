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
        public DbSet<RoleModel> Roles { get; set; }
        public DbSet<UserModel> Users { get; set; }

    }

    public class BookDbInit : DropCreateDatabaseAlways<BookContext>
    {
        protected override void Seed(BookContext db)
        {
            db.Books.Add(new BookModel() { Name = "Война и Мир", Description = "Написал Лев Толстой" });
            db.Books.Add(new BookModel() { Name = "Мастер и Маргарита", Description = "Написал Булгаков" });
            db.Roles.Add(new RoleModel() {Name = "Admin"});
            db.Roles.Add(new RoleModel() { Name = "User" });
            db.Users.Add(new UserModel()
                {
                    Email = "art264400@yandex.ru",
                    Login = "mino",
                    Name = "Артур",
                    RoleId = 1,
                    Surname = "Губайдуллин",
                    Password="123"

                });
            base.Seed(db);
        }
    }
}