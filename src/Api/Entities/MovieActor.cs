using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Entities
{
    public class MovieActor
    {
        public int MovieId { get; set; }    
        public int ActorId { get; set; }
        public string Character { get; set; } = null!;
        public int Order { get; set; }
        public Movie Movie { get; set; }=null!;
        public Actor Actor { get; set; }=null!;
    }
}