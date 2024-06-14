using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObjects.DTOs
{
    public class GetProductResponse
    {
        public List<ProductResponse> Products { get; set; }
        public int?Total { get; set; }
        public int?Size { get; set; }
        public int? Page { get; set; }
    }
}
