using System;
using System.Collections.Generic;

namespace BusinessObjects.Models
{
    public partial class OrderStatus
    {
        public int Id { get; set; }
        public DateTime OrderDate { get; set; }
        public string OrderStatus1 { get; set; } = null!;
        public int OrderId { get; set; }

        public virtual Order Order { get; set; } = null!;
    }
}
