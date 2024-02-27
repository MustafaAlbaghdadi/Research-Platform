using System.ComponentModel.DataAnnotations;

namespace aspcore.Models
{
    public class TableCV
    {
        [Key]
        public long Id { get; set; }
        [Display(Name ="En Name")]
        public string EnName { get; set; }
        [Display(Name = "Ar Name")]
        public string Name { get; set; }
        [Display(Name = "Email")]
        public string Email { get; set; }
        public int depid { get; set; }
        [Display(Name = "Gender")]
        public string img { get; set; }

        public string gender { get; set; }
    }
}
