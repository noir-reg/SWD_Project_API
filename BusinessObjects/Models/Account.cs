using System;
using System.Collections.Generic;

namespace BusinessObjects.Models
{
    public partial class Account
    {
        public Account()
        {
            Comments = new HashSet<Comment>();
            OrderCustomers = new HashSet<Order>();
            OrderStaffs = new HashSet<Order>();
        }

        public int Id { get; set; }
        public string Password { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string? Fullname { get; set; }
        public DateTime? Birthday { get; set; }
        public string Address { get; set; } = null!;
        public bool IsActive { get; set; }
        public bool Gender { get; set; }
        public int? Point { get; set; }
        public string Phone { get; set; } = null!;
        public string? Role { get; set; }

        public virtual ICollection<Comment> Comments { get; set; }
        public virtual ICollection<Order> OrderCustomers { get; set; }
        public virtual ICollection<Order> OrderStaffs { get; set; }
    }
}
