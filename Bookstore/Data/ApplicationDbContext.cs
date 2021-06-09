using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.Data.Sql;
using System;
using System.Collections.Generic;
using System.Text;
using Bookstore.Models;

namespace Bookstore.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        //protected override void OnModelCreating(ModelBuilder builder)
        //{
        //    base.OnModelCreating(builder);
        //}


        public DbSet<BookModel> Books { get; set; }
        public DbSet<CategoryModel> Categories { get; set; }
        public DbSet<ShoppingCartItemModel> ShoppingCartItems { get; set; }
        public DbSet<OrderModel> Order { get; set; }
        public DbSet<OrdersModel> Orders { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            var password = new PasswordHasher<IdentityUser>();
            builder.Entity<IdentityRole>().HasData(
                new IdentityRole
                {
                    Id = "3cc5e8d2-65ef-4d0c-98f9-83073142031b",
                    Name = "Admin",
                    NormalizedName = "ADMIN",
                    ConcurrencyStamp = "0d75306c-ecab-49bf-9220-bbe703949a2e"
                },
                new IdentityRole
                {
                    Id = "3bccac0c-f782-4e4b-b37e-72f27aa87e59",
                    Name = "User",
                    NormalizedName = "USER",
                    ConcurrencyStamp = "ba2020fe-6f56-439d-9a17-e7dfd2b2d38b"
                },
                new IdentityRole
                {
                    Id = "581e4962-61c4-40f3-af1e-c2bfb8693984",
                    Name = "Menager",
                    NormalizedName = "MENAGER",
                    ConcurrencyStamp = "ee637123-2171-42e8-ab18-759a2c475409"
                });
            builder.Entity<IdentityUser>().HasData(
                new IdentityUser
                {
                    Id = "69kjc8ab-d412-4a76-bb7d-e971d2d48c46",
                    UserName = "administrator@email.com",
                    NormalizedUserName = "ADMINISTRATOR@EMAIL.COM",
                    Email = "administrator@email.com",
                    NormalizedEmail = "ADMINISTRATOR@EMAIL.COM",
                    EmailConfirmed = true,
                    PasswordHash = password.HashPassword(null, "Haslo1234!"),
                    SecurityStamp = Guid.NewGuid().ToString()
                });
            builder.Entity<IdentityUserRole<string>>().HasData(
                new IdentityUserRole<string>
                {
                    RoleId = "3cc5e8d2-65ef-4d0c-98f9-83073142031b",
                    UserId = "69kjc8ab-d412-4a76-bb7d-e971d2d48c46"
                });
            builder.Entity<BookModel>().HasData(
                new BookModel
                {
                    Id = 30,
                    Title = "Tomek i przyjaciele",
                    Autor = "Bogumiła Nowak",
                    Amount = 20,
                    Year_of_publish = 2008,
                    ISBN = "2151638514413",
                    Category = "Komedia",
                    Publisher = "Nowa Era"
                },
                new BookModel
                {
                    Id = 31,
                    Title = "Niewiadoma Elvisa",
                    Autor = "Ireneusz Piotrowski",
                    Amount = 20,
                    Year_of_publish = 1998,
                    ISBN = "0521159508353",
                    Category = "Komedia",
                    Publisher = "Nowa Era"
                }, new BookModel
                {
                    Id = 32,
                    Title = "Bogactwo McDonalda",
                    Autor = "Serafina Tomaszewska",
                    Amount = 20,
                    Year_of_publish = 1999,
                    ISBN = "8161084125042",
                    Category = "Dziennik",
                    Publisher = "Simon & Schuster"
                }, new BookModel
                {
                    Id = 33,
                    Title = "Zagadka Neila Armstronga",
                    Autor = "Marcelina Zawadzka",
                    Amount = 20,
                    Year_of_publish = 1948,
                    ISBN = "9130177282184",
                    Category = "Przygodowa",
                    Publisher = "Simon & Schuster"
                }, new BookModel
                {
                    Id = 34,
                    Title = "Kod Gutenberga",
                    Autor = "Klaudiusz Symanski",
                    Amount = 20,
                    Year_of_publish = 1967,
                    ISBN = "3107441797968",
                    Category = "Przygodowa",
                    Publisher = "Nowa Era"
                }, new BookModel
                {
                    Id = 35,
                    Title = "Szarada Newtona",
                    Autor = "Klimek Dudek",
                    Amount = 20,
                    Year_of_publish = 1912,
                    ISBN = "5129929184934",
                    Category = "Science-Fiction",
                    Publisher = "Hachette Livre"
                }, new BookModel
                {
                    Id = 36,
                    Title = "Fortuna Billa Gatesa",
                    Autor = "Chad L. Lunceford",
                    Amount = 20,
                    Year_of_publish = 2012,
                    ISBN = "9779927736852",
                    Category = "Science-Fiction",
                    Publisher = "Penguin Random House"
                }, new BookModel
                {
                    Id = 37,
                    Title = "Szyfr Einsteina",
                    Autor = "John A. Rodriguez",
                    Amount = 20,
                    Year_of_publish = 2005,
                    ISBN = "2528844196531",
                    Category = "Science-Fiction",
                    Publisher = "Macmillan Publishers"
                }, new BookModel
                {
                    Id = 38,
                    Title = "Klejnot Forda",
                    Autor = "Rebecca C. Michaels",
                    Amount = 20,
                    Year_of_publish = 2010,
                    ISBN = "4600695932095",
                    Category = "Romans",
                    Publisher = "Macmillan Publishers"
                }, new BookModel
                {
                    Id = 39,
                    Title = "Enigma Dionizosa",
                    Autor = "Alejandro N. Woodson",
                    Amount = 20,
                    Year_of_publish = 1992,
                    ISBN = "5112456609535",
                    Category = "Romans",
                    Publisher = "Penguin Random House"
                }, new BookModel
                {
                    Id = 40,
                    Title = "Precjoza Kolumba",
                    Autor = "Lori J. Pinkham",
                    Amount = 20,
                    Year_of_publish = 1993,
                    ISBN = "5906930426442",
                    Category = "Romans",
                    Publisher = "Hachette Livre"
                }, new BookModel
                {
                    Id = 41,
                    Title = "Tajemnica Disneya",
                    Autor = "Charles L. Nevarez",
                    Amount = 20,
                    Year_of_publish = 1978,
                    ISBN = "4476558225443",
                    Category = "Romans",
                    Publisher = "Penguin Random House"
                });
            builder.Entity<CategoryModel>().HasData(
                new CategoryModel
                {
                    Id = 11,
                    Category = "Romans"
                }, new CategoryModel
                {
                    Id = 12,
                    Category = "Komedia"
                }, new CategoryModel
                {
                    Id = 13,
                    Category = "Science-Fiction"
                }, new CategoryModel
                {
                    Id = 14,
                    Category = "Przygodowa"
                }, new CategoryModel
                {
                    Id = 15,
                    Category = "Dziennik"
                });
        }
    }
}
