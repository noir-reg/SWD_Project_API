﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObjects.DTOs
{
    public class PaymentRequest
    {
        public long Amount { get; set; }
        public string StripeToken { get; set; }
    }
}
