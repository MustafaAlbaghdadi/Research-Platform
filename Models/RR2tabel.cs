using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace aspcore.Models
{
    public class RR2tabel
    {
        public long ResearchId { get; set; }
        public long ResearcherId { get; set; }
        [Display(Name = "Sequence")]
        public int ResearcherLvl { get; set; }
        public string? ResearcherArName { get; set; }
        public string? ResearcherEnName { get; set; }
        public string? ResearcherDeg { get; set; }
        public string ResearcherDept { get; set; }
        public bool FirstPublished { get; set; }

        public string? img { get; set; }
        [Display(Name = "Gender")]

        public string ResearcherGender { get; set; }
        public long? ResearcherMoney { get; set; }
        public bool? responsible { get; set; }
        public bool? MainR { get; set; }

    }
}
