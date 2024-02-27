using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace aspcore.Models
{
    public class PaymentSetting
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Display(Name = "ImpactFacter Larger Than 5")]
        public int ImpactFacterLargerThan5 { get; set; }
        [Display(Name = "ImpactFacter From 4 To 5")]
        public int ImpactFacterFrom4To5 { get; set; }
        [Display(Name = "ImpactFacter From 3 To 3.999")]
        public int ImpactFacterFrom3To4 { get; set; }
        [Display(Name = "ImpactFacter From 2 To 2.999")]
        public int ImpactFacterFrom2To3 { get; set; }
        [Display(Name = "ImpactFacter From 1 To 1.999")]
        public int ImpactFacterFrom1To2 { get; set; }
        [Display(Name = "Citation Larger Than 20")]
        public int CitationLargerThen20 { get; set; }
        [Display(Name = "Citation From 16 To 20")]
        public int CitationFrom16To20 { get; set; }
        [Display(Name = "Citation From 11 To 15")]
        public int CitationFrom11To15 { get; set; }
        [Display(Name = "Citation From 8 To 10")]
        public int CitationFrom8To10 { get; set; }
        [Display(Name = "Citation From 4 To 7")]
        public int CitationFrom4To7 { get; set; }
        [Display(Name = "Citation From 1 To 3")]
        public int CitationFrom1To3 { get; set; }
        [Display(Name = "Human Department")]
        public int ScopusHumanDepartment { get; set; }
        [Display(Name = "SDG")]
        public int SDG { get; set; }
        [Display(Name = "Q1 First")]
        public int Q1First { get; set; }
        [Display(Name = "Q2 First")]
        public int Q2First { get; set; }
        [Display(Name = "Q3 First")]
        public int Q3First { get; set; }
        [Display(Name = "Q4 First")]
        public int Q4First { get; set; }
        [Display(Name = "Q1 Second")]
        public int Q1Second { get; set; }
        [Display(Name = "Q2 Second")]

        public int Q2Second { get; set; }
        [Display(Name = "Q3 Second")]

        public int Q3Second { get; set; }
        [Display(Name = "Q4 Second")]

        public int Q4Second { get; set; }

        [Display(Name = "Female")]

        public int Female { get; set; }
        //##############

        [Display(Name = "OpenAccess")]

        public int openAccess { get; set; }


        [Display(Name = "external Gloabal")]
        public int externalGloabalResearcher { get; set; }

        [Display(Name = "External Local")]
        public int externalLocalResearcher { get; set; }

        [Display(Name = "Acknowledgment")]
        public int ThanksForMustaqbal { get; set; }
        [Display(Name = "Clarivate")]
        public int inClarivate { get; set; }
        [Display(Name = "Clarivate Only")]
        public int ClarivateOnlly { get; set; }

        [Display(Name = "publisher")]
        public int publisher { get; set; }


        [Display(Name = "Conference First")]

        public long ConferenceFirst { get; set; }
        [Display(Name = "Conference Secend")]

        public long ConferenceSecend { get; set; }
        [Display(Name = "Conference Local Researcher")]

        public long ConferenceLocalResearcher { get; set; }
        [Display(Name = "Conference Global Researcher")]

        public long ConferenceGlobalResearcher { get; set; }

        [Display(Name = "Conference Acknowledgment")]
        public int conferenceAcknowledgment { get; set; }
        [Display(Name = "Grant")]
        public long Grant { get; set; } 
        [Display(Name = "responsible")]
        public long responsible { get; set; }
        
        [Display(Name = "MainR")]
        public long MainR { get; set; }

    }
}
