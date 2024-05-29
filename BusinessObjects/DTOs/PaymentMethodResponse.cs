using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObjects.DTOs
{
    public class PaymentMethodResponse
    {
        public int Id { get; set; }
        public string Method { get; set; } = null!;
    }
}
