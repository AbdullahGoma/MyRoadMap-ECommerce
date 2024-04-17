using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bulky.Models.Entities
{
    public class Product
    {
        public int Id { get; set; } 
        public string Title { get; set; } = null!;
        public string Description { get; set; } = null!;
        public string ISBN { get; set; } = null!;
        public string Author { get; set; } = null!;
        [Range(1, 1000, ErrorMessage = Errors.MaxRange)]
        public double ListPrice { get; set; }
        [Range(1, 1000, ErrorMessage = Errors.MaxRange)]
        public double Price { get; set; }
        [Range(1, 1000, ErrorMessage = Errors.MaxRange)]
        public double Price50 { get; set; }
        [Range(1, 1000, ErrorMessage = Errors.MaxRange)]
        public double Price100 { get; set; } 
    }
}
