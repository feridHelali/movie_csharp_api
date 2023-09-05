using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Api.DTOs
{
    public class GenreCreationDTO
    {
        [StringLength(maximumLength: 150)]
        [Required]
        public string Name { get; set; } = null!;
    }
}