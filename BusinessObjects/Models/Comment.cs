using System;
using System.Collections.Generic;

namespace BusinessObjects.Models
{
    public partial class Comment
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int ProductId { get; set; }
        public string Content { get; set; } = null!;
        public DateTime CommentDate { get; set; }
        public int Rate { get; set; }
        public bool? Status { get; set; }

        public virtual Product Product { get; set; } = null!;
        public virtual Account User { get; set; } = null!;
    }
}
