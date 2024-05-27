using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace aspcore.Models
{
    public class ResearchMUS
    {
        public long Id { get; set; }
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Form_No { get; set; } //todo autoincremnt in db

        [Display(Name = "External Researcher Name")]
        public string? ExtResrchDetail { get; set; }


        [Display(Name = "عنوان البحث")]
        public string title { get; set; }
        [Display(Name = "Research Link")]
        public string link { get; set; }
        [Display(Name = "Scopus Link")]
        public string? SCOPUS_link { get; set; }
        [Display(Name = "Research File")]
        public string fileRes { get; set; }
        [Display(Name = "published")]
        public string published { get; set; }
        [Display(Name = "publish Date")]
        public DateTime pubDate { get; set; }
        [Display(Name = "ISSN")]
        public string ISSNorEISSN { get; set; }
        [Display(Name = "Journal Title")]
        public string journaltitle { get; set; }
        [Display(Name = "Journal Link")]
        public string journalurl { get; set; }
        [Display(Name = "Publisher")]
        public string publisher { get; set; }
        [Display(Name = "Quartile")]
        public int quartile { get; set; }
        [Display(Name = "Cite Score")]
        public double citeScore { get; set; }
        [Display(Name = "Journal Country")]
        public string? JournalCountry { get; set; }

        public int? rankOutOf { get; set; }
        [Display(Name = "Open Access")]
        public string openAccess { get; set; }
        [Display(Name = "No. Researchers")]
        public int? OtherResearch { get; set; }
        [Display(Name = "Applied")]
        public string? appledPaper { get; set; }
        [Display(Name = "Code")]
        public string? code { get; set; }
        [Display(Name = "Upload Date")]
        public DateTime uploadDate { get; set; }
        [Display(Name = "Scopus")]
        public bool? scopas { get; set; }
        [Display(Name = "Clarivate ")]
        public bool clarivate { get; set; }

        public int viewlvl { get; set; }// 1 ok  0 deleted
        [Display(Name = "Uploader Email")]
        public string publisherEmail { get; set; }  // ايميل الشخص الي ضاف الملف
        [Display(Name = "SDG")]
        public string? SDGtype { get; set; }
        [Display(Name = "Note")]
        public string? Notes { get; set; }
        [Display(Name = "College Thanks")]
        public bool? ThanksOFcoll { get; set; }
        [Display(Name = "ImpactFacter")]
        public double? ImpactFacter { get; set; }
        [Display(Name = "External Researcher")]
        public bool ExtResrch { get; set; }
        [Display(Name = "Local Researcher")]
        public bool ExtResrch_Local { get; set; }
        [Display(Name = "Globl Researcher")]
        public bool ExtResrch_Globl { get; set; }
        public string? QRimage { get; set; }
        [Display(Name = "Last UpDate")]
        public DateTime LastUpDate { get; set; }
        public string checkState { get; set; } // 3 IT reject , 2 Check Pendding, 1 Admin pending, 0 Complete ,4 president prining , 5 president Approved , 6 president reject
        public OrderFormat OrderFormat { get; set; }


        [Display(Name = "Reason")]
        public string? RejectReason { get; set; }
        [NotMapped]
        public List<RR2tabel> ResearchersList { get; set; }
        [Display(Name = "المبلغ")]

        public long? totalMoney { get; set; }

        [Display(Name = "SDG")]
        [NotMapped]
        public List<string> SDGList { get; set; }
        [Display(Name = "Human Department")]
        public bool? scopusHumanDepartment { get; set; }
        [Display(Name = "اسماء الباحثين")]
        public string? Names { get; set; }

        [Display(Name = "Amounts")]
        public string? Amounts { get; set; }

        [Display(Name = "Degrees")]

        public string? Degrees { get; set; }
        [Display(Name = "Departments")]
        public string? Departments { get; set; }
        [Display(Name = "attachedFile1")]
        public string attachedFile1 { get; set; }

        [Display(Name = "attachedFile2")]
        public string attachedFile2 { get; set; }
        [Display(Name = "attachedFile3")]
        public string attachedFile3 { get; set; }
        [Display(Name = "attachedFile4")]
        public string attachedFile4 { get; set; }
        public bool externalResearcher { get; set; }
        public bool? GrantInfo { get; set; }


        [Display(Name = "Order Num.")]
        public string OrderNumber { get; set; }
        [Display(Name = "Order Date.")]
        public DateTime OrderDate { get; set; }
        [Display(Name = "Order File.")]
        public string OrderFile { get; set; }   
        
        [Display(Name = "توصية من الشؤون العلمية")]
        public string? ScientificrRcommendation { get; set; }
        [Display(Name = "الاستمارة")]
        public string? ResFormId { get; set; } 
        [Display(Name = "عدد مرات الطباعة")]
        public int PrintCount { get; set; }

    }

    public enum OrderFormat
    {
        ScopusCheckout,// صرف مبلغ
        ScopusSettlement,// تسوية
    }

    


}
