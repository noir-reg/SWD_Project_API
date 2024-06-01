using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObjects.DTOs
{
    public class GetAccountsResponse
    {
        public List<AccountResponse>? Accounts { get; set; }
        public int? Total { get; set; }  
        public int? Size { get; set; }
        public int? Page { get; set; }
    }
}
