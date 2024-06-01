using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObjects.DTOs
{
    public class AccountFilter
    {
        public bool? IsActive { get; set; }
        public int? RoleId {  get; set; }
        public string? NameOrEmailSearchKeyWord { get; set; }
    }
}
