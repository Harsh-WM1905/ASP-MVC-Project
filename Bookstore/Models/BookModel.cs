using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Bookstore.Models
{
    public class BookModel
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public string Autor { get; set; }
        public string Category { get; set; }
        public int Amount { get; set; }
        public int Year_of_publish { get; set; }
        [MaxLength(13)]
        [MinLength(13)]
        public string ISBN { get; set; }
        public string Publisher { get; set; }
    }
}
