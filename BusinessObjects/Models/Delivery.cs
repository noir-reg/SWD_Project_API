using System;
using System.Collections.Generic;

namespace BusinessObjects.Models
{
    public partial class Delivery
    {
        public int Id { get; set; }
        public int? DeliveryManId { get; set; }
        public int? OrderId { get; set; }

        public virtual Account? DeliveryMan { get; set; }
        public virtual Order? Order { get; set; }
    }
}
