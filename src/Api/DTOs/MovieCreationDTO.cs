using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace Api.DTOs
{
    public class MovieCreationDTO
    {
        
        public string Title { get; set; } = null!;
        public bool InTheater { get; set; }
        public DateTime ReleaseDate { get; set; }
        public List<int> Genres { get; set; } = new List<int>();
        public List<MovieActorCreationDTO> MovieActors { get; set; } = new List<MovieActorCreationDTO>();
    }
}