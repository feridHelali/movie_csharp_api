using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.DTOs
{
    public class CommentCreationDTO
    {
        public string? Content { get; set; }
        public bool Recommend { get; set; }
    }
}