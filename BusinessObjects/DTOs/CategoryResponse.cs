﻿using BusinessObjects.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObjects.DTOs
{
    public  class CategoryResponse
    {
    
        public int Id { get; set; }
        public string CategoryName { get; set; } = null!;

     
    }
}
