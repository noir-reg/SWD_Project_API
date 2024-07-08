using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObjects.DTOs
{
    public class UpdatePostRequest
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? BriefContent { get; set; }
        public string? TagSearch { get; set; }
        public bool? Status { get; set; }
    }
}
