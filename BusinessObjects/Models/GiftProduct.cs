using System;
using System.Collections.Generic;

namespace BusinessObjects.Models
{
    public partial class GiftProduct
    {
        public int ProductId { get; set; }
        public int? ExchangePoint { get; set; }

        public virtual Product Product { get; set; } = null!;
    }
}
