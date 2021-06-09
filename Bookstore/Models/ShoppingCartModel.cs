using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Bookstore.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Bookstore.Models
{
    public class ShoppingCartModel
    {
        private readonly ApplicationDbContext dbContext;
        private ShoppingCartModel(ApplicationDbContext context)
        {
            dbContext = context;
        }
        public string ShoppingCartId { get; set; }
        public List<ShoppingCartItemModel> ShoppingCartItems { get; set; }

        public static ShoppingCartModel GetCart(IServiceProvider services)
        {
            ISession session = services.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;
            var context = services.GetService<ApplicationDbContext>();
            string cartId = session.GetString("CartId") ?? Guid.NewGuid().ToString();
            session.SetString("CartId", cartId);
            return new ShoppingCartModel(context) { ShoppingCartId = cartId };
        }

        public void AddToCart(BookModel book)
        {
            //BookModel book = dbContext.Books.Single(b => b.Id == id);
            var shoppingCartItem = dbContext.ShoppingCartItems.SingleOrDefault(
                s => s.Book.Id == book.Id && s.ShoppingCartId == ShoppingCartId);
            if(shoppingCartItem == null)
            {
                shoppingCartItem = new ShoppingCartItemModel 
                { 
                    ShoppingCartId = ShoppingCartId, 
                    Book = book
                };
                dbContext.ShoppingCartItems.Add(shoppingCartItem);
            }
            dbContext.SaveChanges();
        }
        public void Remove(BookModel book)
        {
            //BookModel book = dbContext.Books.Single(b => b.Id == id);
            var shoppingCartItem = dbContext.ShoppingCartItems.SingleOrDefault(
                s => s.Book.Id == book.Id && s.ShoppingCartId == ShoppingCartId);
            if(shoppingCartItem != null)
            {
                dbContext.ShoppingCartItems.Remove(shoppingCartItem);
            }
            dbContext.SaveChanges();
        }
        public List<ShoppingCartItemModel> GetShoppingCartItems()
        {
            return ShoppingCartItems ?? (ShoppingCartItems = dbContext.ShoppingCartItems.Where(
                b => b.ShoppingCartId == ShoppingCartId).Include(s => s.Book).ToList());
        }
        public void ClearCart()
        {
            var cartItems = dbContext.ShoppingCartItems.Where(b => b.ShoppingCartId == ShoppingCartId);
            dbContext.ShoppingCartItems.RemoveRange(cartItems);
            dbContext.SaveChanges();
        }
    }
}
