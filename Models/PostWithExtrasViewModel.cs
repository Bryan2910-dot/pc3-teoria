using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace pc3_teoria.Models
{
    public class PostWithExtrasViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        public string AuthorName { get; set; }
        public List<string> Comments { get; set; } = new();
    }
}