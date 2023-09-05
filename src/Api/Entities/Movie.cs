using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Entities
{
    public class Movie
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public bool InTheater { get; set; }
        public DateTime ReleaseDate { get; set; }
        public HashSet<Comment> Comments { get; set; }=new HashSet<Comment>();
        public HashSet<Genre> Genres { get; set; }= new HashSet<Genre>();
        public List<MovieActor> MovieActor { get; set; } = new List<MovieActor>();
    }
}