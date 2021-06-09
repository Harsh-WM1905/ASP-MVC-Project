using Bookstore.Models;
using Bookstore.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Bookstore.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private ApplicationDbContext dbContext;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            dbContext = context;
        }

        public IActionResult Index()
        {
            List<BookModel> books = dbContext.Books.ToList();
            List<BookModel> rightBooks = new List<BookModel>();
            for (int i = books.Count - 1; i > 0; i--)
            {
                rightBooks.Add(books[i]);
                if (rightBooks.Count == 4)
                {
                    break;
                }
            }
            return View(rightBooks);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [Authorize(Policy = "UserRole")]
        public async Task<IActionResult> SearchBooks(string sortOrder, string searchTitle,string searchAutor, string searchCategory)
        {
            ViewData["TitleSort"] = String.IsNullOrEmpty(sortOrder) ? "title_desc" : "";
            ViewData["AutorSort"] = sortOrder == "Autor" ? "autor_desc" : "Autor";
            ViewData["FilterTitle"] = searchTitle;
            ViewData["FilterAutor"] = searchAutor;
            ViewData["FilterCategory"] = searchCategory;
            var books = from s in dbContext.Books select s;
            if (!String.IsNullOrEmpty(searchTitle) || !String.IsNullOrEmpty(searchAutor) || !String.IsNullOrEmpty(searchCategory))
            {
                books = books.Where(s => s.Title.Contains(searchTitle) || s.Autor.Contains(searchAutor)
                    || s.Category.Contains(searchCategory));
            }
            switch (sortOrder)
            {
                case "title_desc":
                    books = books.OrderByDescending(s => s.Title);
                    break;
                case "Autor":
                    books = books.OrderBy(s => s.Autor);
                    break;
                case "autor_desc":
                    books = books.OrderByDescending(s => s.Autor);
                    break;
                default:
                    books = books.OrderBy(s => s.Title);
                    break;
            } 
            return View(await books.AsNoTracking().ToListAsync());
        }

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

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
