using System.ComponentModel.DataAnnotations;

namespace aspcore.Models
{
    public class DepTable
    {
        [Key]
        public int Id { get; set; }
        public string depname { get; set; }
    }
}
