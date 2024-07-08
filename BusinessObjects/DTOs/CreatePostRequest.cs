using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObjects.DTOs
{
    public class CreatePostRequest
    {
        public int? Author { get; set; }
        public string? Title { get; set; }
        public string? BriefContent { get; set; }
        public string? TagSearch { get; set; }
    }
}
