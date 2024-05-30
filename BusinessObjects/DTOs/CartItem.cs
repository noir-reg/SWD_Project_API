using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObjects.DTOs
{
    public class CartItem
    {
        
        public int? AccountId { get; set; }
        public int? ProductId { get; set; }
        public int? Quantity { get; set; }
        public decimal Price { get; set; }
    }
}
