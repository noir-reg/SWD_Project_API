using System;
using System.Collections.Generic;

namespace BusinessObjects.Models
{
    public partial class ProductDetailImage
    {
        public int Id { get; set; }
        public int? ProductId { get; set; }
        public string? ImageUrl { get; set; }

        public virtual Product? Product { get; set; }
    }
}
