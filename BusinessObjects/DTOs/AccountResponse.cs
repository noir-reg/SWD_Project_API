using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObjects.DTOs
{
    public class AccountResponse
    {
        public int Id { get; set; }
        public string Email { get; set; } = null!;
        public string Fullname { get; set; } = null!;
        public DateTime? Birthday { get; set; }
        public int Roleid { get; set; }
        public string? Address { get; set; }
        public bool IsActive { get; set; }
        public bool? Gender { get; set; }
        public int? Point { get; set; }
        public int? Phone { get; set; }
        public string Role { get; set; } = null!;
    }
}
