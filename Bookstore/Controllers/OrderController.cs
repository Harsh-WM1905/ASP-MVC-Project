using Bookstore.Data;
using Bookstore.Models;
using Bookstore.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;


namespace Bookstore.Controllers
{
    public class OrderController : Controller
    {
        private ApplicationDbContext dbContext;
        private readonly ILogger<OrderController> _logger;
        public OrderController(ApplicationDbContext context, ILogger<OrderController> logger)
        {
            dbContext = context;
            _logger = logger;
        }
        public IActionResult Index()
        {
            var current_user = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            List<BookModel> borrowedBooks = new List<BookModel>();
            List<DateTime> orderDates = new List<DateTime>();
            List<int> orders = new List<int>();
            List<bool> ifBool = new List<bool>();
            
            if (dbContext.Orders.Any() == true)
            {
                var list = dbContext.Orders.Where(b => b.ReadyToPickUp == true).ToList();
                
                foreach (var item in list)
                {
                        if (current_user.Equals(item.IdentityUserId))
                        {
                            var orderId = item.OrderId;
                            var date = item.OrderDate;
                            var listOrder = dbContext.Order.ToList();
                            foreach (var item2 in listOrder)
                            {
                                if (item2.OrderId.Equals(orderId))
                                {
                                    var book = dbContext.Books.SingleOrDefault(b => b.Id == item2.BookId);
                                    borrowedBooks.Add(book);
                                    ifBool.Add(item.PickedUp);
                                    orders.Add(item.Id);
                                    orderDates.Add(date);
                                }   
                            }
                            
                        }
                    
                }
                ViewData["IfBool"] = ifBool;
                ViewData["BorrowedBooks"] = borrowedBooks;
                ViewData["OrderDate"] = orderDates;
                ViewData["Orders"] = orders;
                ViewData["CountOrders"] = borrowedBooks.Count();
            }
            
            return View();
        }

        public IActionResult ReturnBook(int id)
        {
            var order = dbContext.Orders.Single(b => b.Id == id);
            var orderId = dbContext.Order.Single(b => b.OrderId == order.OrderId);
            var book = dbContext.Books.Single(b => b.Id == orderId.BookId);
            ViewData["TitleBook"] = book.Title;
            ViewData["Autor"] = book.Autor;
            ViewData["Year"] = book.Year_of_publish;
            ViewData["Category"] = book.Category;
            return View(order);
        }
        public IActionResult ReturnBookFinal(int id)
        {
            OrdersModel orders = dbContext.Orders.Single(b => b.Id == id);
            var orderId = dbContext.Order.Single(b => b.OrderId == orders.OrderId);
            var book = dbContext.Books.Single(b => b.Id == orderId.BookId);
            book.Amount++;
            dbContext.Orders.Remove(orders);
            dbContext.Order.Remove(orderId);
            dbContext.SaveChanges();
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> PickedUp(int id)
        {
            var order = await dbContext.Orders.SingleAsync(b => b.Id == id);
            order.PickedUp = true;
            dbContext.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
