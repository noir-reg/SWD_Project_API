using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObjects.DTOs
{
    public class DeliveryOrder
    {
        public int Id { get; set; }
        public string CustomerName { get; set; }
        public int CustomerId { get; set; }
        public string DeliveryManName { get; set; }
        public int? DeliveryManId { get; set; }
        public int? OrderId { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public decimal? Total { get; set; }
        public string PaymentMethod { get; set; }
        public string Status { get; set; }
    }
}
