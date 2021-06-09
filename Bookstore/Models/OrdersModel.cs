using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bookstore.Models;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Bookstore.Models
{
    public class OrdersModel
    {
        [Key]
        public int Id { set; get; }
        public DateTime OrderDate { get; set; }
        public bool ReadyToPickUp { get; set; }
        public bool PickedUp { get; set; }
        public string IdentityUserId { get; set; }
        public int OrderId { get; set; }
        public virtual IdentityUser IdentityUser { get; set; }
        public virtual OrderModel Order { get; set; }
        

    }
}
