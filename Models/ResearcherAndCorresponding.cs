using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace aspcore.Models
{
    public class ResearcherAndCorresponding
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; } 
        public string? Email { get; set; }
        [Required]
        public string uploaderEmail { get; set; } 
        [Required]
        public CorrespondingType Type { get; set; }
        public bool Archive { get; set; }
        public DateTime CreateDate { get; set; }


    }
    public enum CorrespondingType
    {
        Corresponding,
        Researcher
    }
}
