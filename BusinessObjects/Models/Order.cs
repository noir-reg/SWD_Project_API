using System;
using System.Collections.Generic;

namespace BusinessObjects.Models
{
    public partial class Order
    {
        public Order()
        {
            OrderDetails = new HashSet<OrderDetail>();
            OrderStatuses = new HashSet<OrderStatus>();
        }

        public int Id { get; set; }
        public int CustomerId { get; set; }
        public int? StaffId { get; set; }
        public int? PaymentId { get; set; }

        public virtual Payment? Payment { get; set; }
        public virtual Account? Staff { get; set; }
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
        public virtual ICollection<OrderStatus> OrderStatuses { get; set; }
    }
}
