using BusinessObjects.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObjects.DTOs
{
    public class OrderResponse
    {
        public int Id { get; set; }
        public int CustomerId { get; set; } 
        public string Payment { get; set; }
        
        public decimal? Total { get; set; }
        public OrderStatus Status { get; set; }
        public List<OrderDetail> OrderDetails { get; set; }
    }
}
