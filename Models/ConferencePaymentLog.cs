using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace aspcore.Models
{
    public class ConferencePaymentLog
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public long ConferenceId { get; set; }
        public int ConferenceMoney { get; set; }
        public int? externalResearcherMoney { get; set; }
        public int? AcknowledgeMoney { get; set; }
        public int? femaleM { get; set; }
        public int ConferenceTotalAmount { get; set; }


    }
}
