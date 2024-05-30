using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObjects.DTOs
{
    public class CreateOrderRequest
    {
        public int CustomerId { get; set; }
        public int? StaffId { get; set; }
        public int? PaymentId { get; set; }
        public DateTime OrderDate { get; set; }
        public string OrderStatus1 { get; set; } = null!;
        public decimal Total { get; set; }
        public List<CreateOrderDetailRequest> OrderDetails { get; set; }
    }
}
