using System;
using System.ComponentModel.DataAnnotations;

namespace Api.Entities
{
    public class Genre
    {
        public int Identifier { get; set; }

        //[StringLength(maximumLength:150)]
        public string Name { get; set; }=null!;
        public HashSet<Movie> Movies { get; set; } = new HashSet<Movie>();
    }
}