using System;
using System.Collections.Generic;

namespace BusinessObjects.Models
{
    public partial class Post
    {
        public int PostId { get; set; }
        public int? Author { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? LastModified { get; set; }
        public string? Title { get; set; }
        public string? BriefContent { get; set; }
        public string? TagSearch { get; set; }
        public bool? Status { get; set; }
    }
}
