using System;
using System.Collections.Generic;

namespace BusinessObjects.Models
{
    public partial class Product
    {
        public Product()
        {
            Comments = new HashSet<Comment>();
            OrderDetails = new HashSet<OrderDetail>();
            ProductDetailImages = new HashSet<ProductDetailImage>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public decimal Price { get; set; }
        public float Discount { get; set; }
        public int CategoryId { get; set; }
        public int Stock { get; set; }
        public int IsAvailable { get; set; }
        public int QuantitySold { get; set; }
        public string? Image { get; set; }

        public virtual Category Category { get; set; } = null!;
        public virtual ICollection<Comment> Comments { get; set; }
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
        public virtual ICollection<ProductDetailImage> ProductDetailImages { get; set; }
    }
}
