using System.ComponentModel.DataAnnotations;

namespace Api.DTOs
{
    public class ActorCreationDTO
    {
        public int Id { get; set; }
        
        [StringLength(maximumLength:150)]
        [Required]
        public string Name { get; set; }=null!;
        public decimal Fortune { get; set; }
        public DateTime DateOfBirth { get; set; }
    }
}