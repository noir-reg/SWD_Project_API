﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObjects.DTOs
{
    public class CreateImageRequest
    {
        public string Url { get; set; } = null!;
        public int ProductId { get; set; }
    }
}
