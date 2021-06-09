using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Bookstore.Data;
using Bookstore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bookstore.Controllers
{
    [Authorize(Policy = "UserRole")]
    public class BookController : Controller
    {
        private ApplicationDbContext dbContext;
        public BookController(ApplicationDbContext context)
        {
            dbContext = context;
        }
        // GET: BookController
        
        public ActionResult Index()
        {
            var books = dbContext.Books.ToList();
            return View(books);
        }

        // GET: BookController/Details/5
        public ActionResult Details(int id)
        {
            var book = dbContext.Books.Single(b => b.Id == id);
            return View(book);
        }

        public ActionResult AddToCart(int id)
        {
            var book = dbContext.Books.Single(b => b.Id == id);
            return View();
        }
    }
}
