using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Bookstore.Models
{
    public class ShoppingCartItemModel
    {
        [Key]
        public int ShoppingCartItemId { get; set; }
        public BookModel Book { get; set; }
        public string ShoppingCartId { get; set; }
    }
}
