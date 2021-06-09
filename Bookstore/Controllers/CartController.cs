using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
//using Bookstore.Helper;
using Bookstore.Models;
using Bookstore.Data;
using System.Web;
using System.Net.Http;
using System.Net;
using Microsoft.AspNetCore.Http;

namespace Bookstore.Controllers
{
    public class CartController : Controller
    {
        private ApplicationDbContext dbContext;

        public CartController(ApplicationDbContext context)
        {
            this.dbContext = context;
        }
        public IActionResult Index()
        {
            //var cart = SessionHelper.GetObjectFromJson<List<BookModel>>(HttpContext.Session, "cart");
            //var cart2 = SessionHelper.GetObjectFromJson<ApplicationDbContext>(HttpContext.Session, "cart");
            //ViewBag.cart = cart2;
            return View();
        }   
    }
}
