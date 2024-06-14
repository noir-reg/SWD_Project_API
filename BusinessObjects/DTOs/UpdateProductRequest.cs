using BusinessObjects.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObjects.DTOs
{
    public class UpdateProductRequest
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public decimal Price { get; set; }
        public float Discount { get; set; }
        public int? Category { get; set; }
        public int Stock { get; set; }
        public int IsAvailable { get; set; }
        public int QuantitySold { get; set; }
        public string? Image { get; set; }
        public bool? IsPreorder { get; set; }
        public bool? IsGift { get; set; }
        public int? GiftPoint { get; set; }
        public int? Capacity { get; set; }
        public string? Origin { get; set; }
        public string? Brand { get; set; }
        public int? Age { get; set; }
        public string? Size { get; set; }
        public string? Description { get; set; }

    }
}
