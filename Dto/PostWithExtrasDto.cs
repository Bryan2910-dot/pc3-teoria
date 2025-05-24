using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using pc3_teoria.Models;

namespace pc3_teoria.Dto
{
    public class PostWithExtrasDto
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Body { get; set; }
        public User Author { get; set; }
        public List<Comment> Comments { get; set; }
    }
}