using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObjects.DTOs
{
    public class CreateCommentDTO
    {
        public int UserId { get; set; }
        public int ProductId { get; set; }
        public string Content { get; set; } = null!;
        public DateTime CommentDate { get; set; }
        public int Rate { get; set; }
        public bool? Status { get; set; }
    }
}
