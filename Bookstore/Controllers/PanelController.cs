using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bookstore.Data;
using Bookstore.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Security.Claims;
using Microsoft.Extensions.Logging;

namespace Bookstore.Controllers
{
    //[Authorize(Policy = "AdminRole")]
    [Authorize(Policy = "UserMenager")]
    public class PanelController : Controller
    {
        private ApplicationDbContext dbContext;
        private readonly RoleManager<IdentityRole> roleMenager;
        private readonly ILogger<PanelController> _logger;

        public PanelController(ApplicationDbContext context, RoleManager<IdentityRole> roleManager, ILogger<PanelController> logger)
        {
            dbContext = context;
            roleMenager = roleManager;
            _logger = logger;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult BookList()
        {
            var books = dbContext.Books.ToList();
            return View(books);
        }
        public IActionResult Book(int id)
        {
            var book = dbContext.Books.Single(b => b.Id == id);
            return View(book);
        }
        public IActionResult CreateCategory()
        {
            return View(new CategoryModel());
        }
        [HttpPost]
        public IActionResult CreateCategory(CategoryModel _category)
        {
            dbContext.Categories.Add(_category);
            dbContext.SaveChanges();
            return RedirectToAction("CategoryList");
        }

        public async Task<IActionResult> Create()
        {
            var cater = await dbContext.Categories.Where(t => t.Category != null).ToListAsync();
            ViewData["Categories"] = new SelectList(cater, "Category", "Category");
            return View(new BookModel());
        }
        
        [HttpPost]
        public IActionResult Create(BookModel @book)
        {

            dbContext.Books.Add(@book);
            dbContext.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult CategoryList()
        {
            var categoriess = dbContext.Categories.ToList();
            return View(categoriess);
        }

        public IActionResult CategoryEdit(int id)
        {
            var category = dbContext.Categories.Single(b => b.Id == id);
            return View(category);
        }
        [HttpPost]
        public IActionResult CategoryEdit(CategoryModel category2, int id)
        {
            CategoryModel category1 = dbContext.Categories.Single(b => b.Id == id);
            category1.Category = category2.Category;


            dbContext.SaveChangesAsync();
            return RedirectToAction("CategoryList");
        }

        public IActionResult DeleteCategory(int id)
        {
            var category = dbContext.Categories.Single(b => b.Id == id);
            return View(category);
        }
        [HttpPost]
        public IActionResult DeleteCategory(CategoryModel category2, int id)
        {
            CategoryModel category1 = dbContext.Categories.Single(b => b.Id == id);
            dbContext.Categories.Remove(category1);
            dbContext.SaveChanges();
            return RedirectToAction("CategoryList");
        }

        public IActionResult Details(int id)
        {
            var book = dbContext.Books.Single(b => b.Id == id);
            return View(book);
        }
        public async Task<IActionResult> Edit(int id)
        {
            var cater = await dbContext.Categories.Where(t => t.Category != null).ToListAsync();
            ViewData["Categories"] = new SelectList(cater, "Category", "Category");
            var book = dbContext.Books.Single(b => b.Id == id);
            return View(book);
        }
        [HttpPost]
        public IActionResult Edit(BookModel book, int id)
        {
            BookModel book1 = dbContext.Books.Single(b => b.Id == id);
            book1.Title = book.Title;
            book1.Autor = book.Autor;
            book1.Amount = book.Amount;

            dbContext.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Delete(int id)
        {
            var book = dbContext.Books.Single(b => b.Id == id);
            return View(book);
        }
        [HttpPost]
        public IActionResult Delete(BookModel book, int id)
        {
            BookModel book1 = dbContext.Books.Single(b => b.Id == id);
            dbContext.Books.Remove(book1);
            dbContext.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> DeleteUser(string id)
        {
            
            var user = await dbContext.Users.SingleAsync(b => b.Id == id);
            dbContext.Users.Remove(user);
            dbContext.SaveChanges();
            return RedirectToAction("UserList");
        }

        [HttpPost]
        public async Task<IActionResult> ConfirmEmail(string id)
        {
            var user = await dbContext.Users.SingleAsync(b => b.Id == id);
            user.EmailConfirmed = true;
            dbContext.SaveChanges();
            return RedirectToAction("UserList");
        }

        [HttpGet]
        public IActionResult UserList(string id)
        {
            
            var adminUserId = dbContext.Roles.SingleOrDefault(b => b.Name.Equals("Admin"));
            var userUserId = dbContext.Roles.SingleOrDefault(b => b.Name.Equals("User"));
            var managerUserId = dbContext.Roles.SingleOrDefault(b => b.Name.Equals("Menager"));

            string adminId = adminUserId.Id;
            string userId = userUserId.Id;
            string menagerId = managerUserId.Id;


            List<string> adminList = new List<string>();
            List<string> userList = new List<string>();
            List<string> managerList = new List<string>();
            
            foreach(var userR in dbContext.UserRoles)
            {
                if (userR.RoleId.Equals(adminId))
                {
                    adminList.Add(userR.UserId);
                }
                if (userR.RoleId.Equals(userId))
                {
                    userList.Add(userR.UserId);
                }
                if (userR.RoleId.Equals(menagerId))
                {
                    managerList.Add(userR.UserId);
                }
            }

            ViewData["AdminRole"] = adminList;
            ViewData["UserRole"] = userList;
            ViewData["ManagerRole"] = managerList;

            var current_user = this.User.FindFirstValue(ClaimTypes.NameIdentifier);//id zalogowanego usera
            Boolean isManager = false;
            if (managerList.Contains(current_user))
            {
                isManager = true;
            }
            ViewBag.CurrentUser = current_user;
            ViewBag.CurrentUserRole = isManager;

            var users = dbContext.Users;
            return View(users);
        }

        [HttpGet]
        public IActionResult RoleList()
        {
            var roles = roleMenager.Roles.ToList();
            return View(roles);
        }

        [HttpGet]
        public IActionResult OrdersList()
        {
            List<string> userNames = new List<string>();//lista stringów id userów
            List<string> bookTitles = new List<string>();
            List<string> orders = new List<string>();//tylko user id 
            List<int> ordersIds = new List<int>();//id szczególów zamówienia
            List<DateTime> dates = new List<DateTime>();
            List<int> ids = new List<int>();
            List<bool> acceptedOrder = new List<bool>();
            List<bool> pickedOrder = new List<bool>();
            List<bool> dateExpired = new List<bool>();
            DateTime date = DateTime.Now;

            int pickUpTime = dbContext.pickUpTimes.Single(b => b.Id == 1).TimeToPickUpOrder;
            var adminUserId = dbContext.Roles.SingleOrDefault(b => b.Name.Equals("Admin"));
            var current_user = this.User.FindFirstValue(ClaimTypes.NameIdentifier);

            List<string> adminList = new List<string>();

            foreach (var userR in dbContext.UserRoles)
            {
                if (userR.RoleId.Equals(adminUserId.Id))
                {
                    adminList.Add(userR.UserId);
                }
            }
            
            bool ifAdmin = false;
            if (adminList.Contains(current_user))
            {
                ifAdmin = true;
            }
            ViewData["ifAdmin"] = ifAdmin;
            var orderList = dbContext.Orders.ToList();
            orders = dbContext.Orders.Select(x => x.IdentityUserId).ToList();
            ordersIds = dbContext.Orders.Select(x => x.OrderId).ToList();
            dates = dbContext.Orders.Select(x => x.OrderDate).ToList();
            var usersId = dbContext.Users.ToList();
            if(dbContext.Orders.Any() == true)
            {
                foreach(var item in orderList)
                {
                    ids.Add(item.Id);
                    var user = dbContext.Users.Single(b => b.Id == item.IdentityUserId);
                    userNames.Add(user.UserName);
                    var bookId = dbContext.Order.Single(b => b.OrderId == item.OrderId);
                    var bookTitle = dbContext.Books.Single(v => v.Id == bookId.BookId);
                    bookTitles.Add(bookTitle.Title);
                    acceptedOrder.Add(item.ReadyToPickUp);
                    pickedOrder.Add(item.PickedUp);
                    if ((date - item.AcceptedDate).TotalDays < pickUpTime)
                    {
                        dateExpired.Add(true);
                    }
                    else
                    {
                        dateExpired.Add(false);
                    }
                }
            }
            

            ViewData["Accepted"] = acceptedOrder;
            ViewData["DateExpired"] = dateExpired;
            ViewData["PickedUp"] = pickedOrder;
            ViewData["OrdersId"] = ids;//id zamówien
            ViewData["Users"] = userNames; // nazwy użytkowników
            ViewData["Books"] = bookTitles; // tytuły książek
            ViewData["Dates"] = dates; // daty
            ViewData["OrdersCount"] = userNames.Count();

            int days = dbContext.pickUpTimes.Single(b => b.Id == 1).TimeToPickUpOrder;
            ViewData["Days"] = days;

            return View();
        }

        public async Task<IActionResult> AcceptOrder(int id)
        {
            var order = await dbContext.Orders.SingleAsync(b => b.Id == id);
            order.ReadyToPickUp = true;
            order.AcceptedDate = DateTime.Now;
            dbContext.SaveChanges();
            return RedirectToAction("OrdersList");
        }

        public async Task<IActionResult> CancelOrder(int id)
        {
            var orders = await dbContext.Orders.SingleAsync(b => b.Id == id);
            var orderId = await dbContext.Order.SingleAsync(b => b.OrderId == orders.OrderId);
            var book = await dbContext.Books.SingleAsync(b => b.Id == orderId.BookId);
            book.Amount++;
            dbContext.Orders.Remove(orders);
            dbContext.Order.Remove(orderId);
            dbContext.SaveChanges();
            return RedirectToAction("OrdersList");
        }

        public ActionResult SetDays(int numberEnter)
        {
            int data = numberEnter;
            var days = dbContext.pickUpTimes.Single(b => b.Id == 1);
            days.TimeToPickUpOrder = data;
            dbContext.SaveChanges();
            return RedirectToAction("OrdersList");
        }
    }
}
