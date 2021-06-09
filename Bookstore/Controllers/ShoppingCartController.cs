using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bookstore.Data;
using Bookstore.Models;
using Microsoft.AspNetCore.Authorization;
using Bookstore.ViewModels;
using System.Security.Claims;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Bookstore.Controllers
{
    public class ShoppingCartController : Controller
    {
        private readonly ApplicationDbContext dbContext;
        private readonly ShoppingCartModel shoppingCart;
        private readonly IHttpContextAccessor contextAccessors;
        private readonly ILogger<ShoppingCartController> _logger;
        public List<int> ordersIds;

        public ShoppingCartController(ApplicationDbContext context, ShoppingCartModel shopping, 
            IHttpContextAccessor accessors, ILogger<ShoppingCartController> logger)
        {
            dbContext = context;
            shoppingCart = shopping;
            contextAccessors = accessors;
            _logger = logger;
        }
        [Authorize]
        public ViewResult Index()
        {
            var items = shoppingCart.GetShoppingCartItems();
            shoppingCart.ShoppingCartItems = items;

            var shopcartviewModel = new ShoppingCartViewModel
            {
                ShoppingCart = shoppingCart
            };
            return View(shopcartviewModel);
        }

        [Authorize]
        public RedirectToActionResult AddToShoppingCart(int bookId)
        {
            var selectedBook = dbContext.Books.FirstOrDefault(b => b.Id == bookId);
            if(selectedBook != null)
            {
                shoppingCart.AddToCart(selectedBook);
            }
            return RedirectToAction("Index");
        }

        public RedirectToActionResult RemoveFromShoppingCart(int bookId)
        {
            var selectedBook = dbContext.Books.FirstOrDefault(b => b.Id == bookId);
            if (selectedBook != null)
            {
                shoppingCart.Remove(selectedBook);
            }
            return RedirectToAction("Index");
        }

        public IActionResult Gratulations()
        {
            return View();
        }

        public RedirectToActionResult CheckOut()
        {
            var items = shoppingCart.GetShoppingCartItems();
            shoppingCart.ShoppingCartItems = items;

            var shopcartviewModel = new ShoppingCartViewModel
            {
                ShoppingCart = shoppingCart
            };
            var current_user = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            string sessionId = contextAccessors.HttpContext.Session.GetString("CartId");
            ordersIds = new List<int>();
            var orders = dbContext.ShoppingCartItems.Where(b => b.ShoppingCartId == sessionId).ToList();
            if (dbContext.ShoppingCartItems.Where(b => b.ShoppingCartId == sessionId).Count() != 0)
            {
                foreach (var item in orders)
                {
                    var order = new OrderModel
                    {
                        OrderDate = DateTime.Now,
                        Book = item.Book
                    };
                    item.Book.Amount--;
                    dbContext.Order.Add(order);
                    dbContext.SaveChanges();
                    ordersIds.Add(order.OrderId);
                }
                
            }
            var ordersList = dbContext.Order.ToList();
            foreach (var item in ordersList)
            {
                if (ordersIds.Contains(item.OrderId))
                {
                    var personOrders = new OrdersModel
                    {
                        IdentityUserId = current_user,
                        OrderDate = DateTime.Now,
                        OrderId = item.OrderId,
                        ReadyToPickUp = false,
                        PickedUp = false
                    };
                    dbContext.Orders.Add(personOrders);
                    dbContext.SaveChanges();
                }
            }
            shoppingCart.ClearCart();
            return RedirectToAction("Gratulations");
        }
    }
}
