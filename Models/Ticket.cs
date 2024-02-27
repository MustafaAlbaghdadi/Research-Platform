using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace aspcore.Models
{
    public class Ticket
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        public string Address { get; set; }
        public bool IsOpein { get; set; }

        public string userId { get; set; }
        public DateTime LastUpdate { get; set; }
        public DateTime CreateDate { get; set; }
        [NotMapped]
        public List<Comment> Comments { get; set; }


    }
}
