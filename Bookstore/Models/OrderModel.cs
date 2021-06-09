using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Bookstore.Models;

namespace Bookstore.Models
{
    public class OrderModel
    {
        [Key]
        public int OrderId { get; set; }
        public DateTime OrderDate { get; set; }

        [ForeignKey("BookModel")]
        public int BookId { get; set; }
        public virtual BookModel Book { get; set; }
    }
}
