using System;
using System.Collections.Generic;

namespace BusinessObjects.Models
{
    public partial class Product
    {
        public Product()
        {
            Carts = new HashSet<Cart>();
            Comments = new HashSet<Comment>();
            Images = new HashSet<Image>();
            OrderDetails = new HashSet<OrderDetail>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public decimal Price { get; set; }
        public float Discount { get; set; }
        public int? Category { get; set; }
        public int Stock { get; set; }
        public int IsAvailable { get; set; }
        public int QuantitySold { get; set; }
        public string? Image { get; set; }

        public virtual Category? CategoryNavigation { get; set; }
        public virtual GiftProduct? GiftProduct { get; set; }
        public virtual ICollection<Cart> Carts { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
        public virtual ICollection<Image> Images { get; set; }
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
