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
            this.Rate   = cmt.Rate;
            this.Status = cmt.Status;
            this.Username = cmt.User.Fullname;
        }
        public CommentDTO() { }
        
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Username { get; set; }
        public int ProductId { get; set; }
        public string Content { get; set; } = null!;
        public int Rate { get; set; }
        public bool? Status { get; set; }
    }
}
