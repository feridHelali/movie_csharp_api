using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Entities
{
    public class Actor
    {
        public int Id { get; set; }
        public string Name { get; set; }=null!;
        public decimal Fortune { get; set; }
        public DateTime DateOfBirth { get; set; }
        public HashSet<MovieActor> MovieActor { get; set; }=new HashSet<MovieActor>();
    }
}