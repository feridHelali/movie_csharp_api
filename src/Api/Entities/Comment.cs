using System.Net.Mime;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Entities
{
    public class Comment
    {
        public int  Id { get; set; }
        public string? Content { get; set; }
        public bool Recommend { get; set; }
        public int MovieId { get; set; }
        public Movie Movie { get; set; } = null!;
    }
}