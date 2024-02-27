using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace aspcore.Models
{
    public class ResearcherTable
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public string ResearchTitle { get; set; }

        [Required]
        public string ResearchLink { get; set; }

        [Required]
        public string CorrespondingAuthors { get; set; }
        [Required]
        public string ResearcherName { get; set; }
        public string? ExternalResearcher { get; set; }

        [Required]
        public string ResearcherEmail { get; set; }
        public string? JournalTitle { get; set; }
        public int? JournalQuarter { get; set; }
        public int? ResearcherPosition { get; set; }
        public int? BatchNo { get; set; }
        public int? CorrPaidAmount { get; set; }
        public DateTime? CorrPaidDate { get; set; }
        public string? CorrRecipientName { get; set; }
        public string? CorrReceivingSide { get; set; }
        public string? CorrPaidArder { get; set; }
        public string? ResearchAbstract { get; set; }
        public string? TotalAmountDesFile { get; set; }
        public int? TotalAmountReceived { get; set; }
        public string? RecipientMoneyName { get; set; }
        [Required]
        public DateTime CreateDate { get; set; }
        
        [Required]
        public DateTime LastUpDate { get; set; }

        [Required]
        public int Status { get; set; }

        public bool Archive { get; set; }
        public string? Note { get; set; }
        [Required]
        public string UploaderEmail { get; set; }
        public string? UpdaterEmail { get; set; }


    }
}
