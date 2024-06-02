using BusinessObjects.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObjects.DTOs
{
    public class CommentDTO
    {
        public CommentDTO(Comment cmt) { 
            this.Id = cmt.Id;
            this.Content = cmt.Content;
            this.UserId = cmt.UserId;
            this.ProductId = cmt.ProductId;
            this.CommentDate = cmt.CommentDate;
            this.Rate   = cmt.Rate;
            this.Status = cmt.Status;
        }
        public CommentDTO() { }
        
        public int Id { get; set; }
        public int UserId { get; set; }
        public int ProductId { get; set; }
        public string Content { get; set; } = null!;
        public DateTime CommentDate { get; set; }
        public int Rate { get; set; }
        public bool? Status { get; set; }
    }
}
