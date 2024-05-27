using System;
using System.Collections.Generic;

namespace BusinessObjects.Models
{
    public partial class Image
    {
        public int Id { get; set; }
        public string Url { get; set; } = null!;
        public int ProductId { get; set; }

        public virtual Product Product { get; set; } = null!;
    }
}
