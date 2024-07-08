using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObjects.DTOs
{
    public class PostResponse
    {
        public int PostId { get; set; }
        public string? Author { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? LastModified { get; set; }
        public string? Title { get; set; }
        public string? TagSearch { get; set; }
        public bool? Status { get; set; }
    }
}
