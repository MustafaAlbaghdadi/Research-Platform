using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace aspcore.Models
{
    public class ConferenceResearch
    {
      
        public long ConferenceId { get; set; }
        public long ResearcherId { get; set; }
        [Display(Name = "Sequence")]
        public int Sequence { get; set; }
        public int DepartmentId { get; set; }
        public string DepartmentTitle { get; set; }

        public string? ResearcherArName { get; set; }
        public string? ResearcherEnName { get; set; }
        public string? ResearcherDeg { get; set; }
        public bool FirstPublished { get; set; }

        public string? img { get; set; }
        [Display(Name = "Gender")]

        public string ResearcherGender { get; set; }
        public long ResearcherMoney { get; set; }
    }
}
