﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace BusinessObjects.DTOs;

public class CreateCartResponse
    

{
     
    public bool IsSuccess { get; set; }
    public string Message {  get; set; }    

}
