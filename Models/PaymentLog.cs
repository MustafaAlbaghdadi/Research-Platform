using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace aspcore.Models
{
    public class PaymentLog
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public long ResearchId { get; set; }
        public long? quartileMoney { get; set; }
        public long? clarivateMoney { get; set; }
        public long? ExtResrchMoney { get; set; }
        public long? ThanksOFcollMoney { get; set; }
        public long? ImpactFacterMoney { get; set; }
        public long? SDGMoney { get; set; }
        public long? publishedMoney { get; set; }
        public long? openAccessMoney { get; set; }
        public long? femaleM { get; set; }
        public long? citationM { get; set; }
        public long? other { get; set; }
        public string? note { get; set; }
        public long total { get; set; }
        public long? scopusHumanDepartmentMoney { get; set; }
        public long? GrantMoney { get; set; }
        public long? responsibleMoney { get; set; }
        public long? MainRMoney { get; set; }


    }
}
