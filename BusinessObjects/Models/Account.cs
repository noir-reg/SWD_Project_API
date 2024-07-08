using System;
using System.Collections.Generic;

namespace BusinessObjects.Models
{
    public partial class Account
    {
        public Account()
        {
            Carts = new HashSet<Cart>();
            Comments = new HashSet<Comment>();
            Deliveries = new HashSet<Delivery>();
            OrderCustomers = new HashSet<Order>();
            OrderStaffs = new HashSet<Order>();
        }

        public int Id { get; set; }
        public string? Password { get; set; }
        public string Email { get; set; } = null!;
        public string Fullname { get; set; } = null!;
        public DateTime? Birthday { get; set; }
        public int Roleid { get; set; }
        public string? Address { get; set; }
        public bool IsActive { get; set; }
        public bool? Gender { get; set; }
        public int? Point { get; set; }
        public string? Phone { get; set; }

        public virtual Role Role { get; set; } = null!;
        public virtual ICollection<Cart> Carts { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
        public virtual ICollection<Delivery> Deliveries { get; set; }
        public virtual ICollection<Order> OrderCustomers { get; set; }
        public virtual ICollection<Order> OrderStaffs { get; set; }
    }
}
