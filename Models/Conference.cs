using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace aspcore.Models
{
    public class Conference
    {
        public long ID { get; set; }
        [Display(Name = "Code")]
        public int? Code { get; set; }// added when approve 
        [Display(Name = "Research Title")]
        public string ResearchTitle { get; set; }
        public string MainFile { get; set; }
        [Display(Name = "Publish Date")]
        public DateTime PublishDate { get; set; }
        [Display(Name = "Conference Title")]
        public string Title { get; set; }
        [Display(Name = "Address")]
        public string Address { get; set; }
        [Display(Name = "Publisher")]
        public string? Publisher { get; set; }

        [Display(Name = "Conference Type")]
        public string Type { get; set; }
        [Display(Name = "Attach1")]

        public string? Attach1 { get; set; }
        [Display(Name = "Attach2")]

        public string? Attach2 { get; set; }


        [Display(Name = "with Privite College")]
        public bool PriviteCollege { get; set; }
        [Display(Name = "with Public College")]
        public bool PublicCollege { get; set; }
        [Display(Name = "with Global College")]
        public bool GlobalCollege { get; set; }

        [Display(Name = "Acknowledge")]
        public bool Acknowledge { get; set; }
        [Display(Name = "Total Amount")]
        public int TotalAmount { get; set; }
        [Display(Name = "Create Date")]
        public DateTime CreateDate { get; set; }
        [Display(Name = "Last Update")]
        public DateTime LastUpdate { get; set; }
        [Display(Name = "Status")]
        public ConferenceStatus Status { get; set; }
        [Display(Name = "Reject Reson")]
        public string? RejectReson { get; set; }
        [Display(Name = "Uploader")]
        public string UploaderEmail { get; set; }
        public string QRImage { get; set; }
        public string? ScopusLink { get; set; }
        public string? ResearchLink { get; set; }
        [Display(Name = "Names")]
        public string? Names { get; set; }
        [Display(Name = "Amounts")]
        public string? Amounts { get; set; }
        [Display(Name = "Degrees")]
        public string? Degrees { get; set; }
        [Display(Name = "Departments")]
        public string? Departments { get; set; }
        [NotMapped]
        public List<ConferenceResearch> ConferenceResearchesList { get; set; } = new List<ConferenceResearch>();
        [Display(Name = "Order File.")]
        public string OrderFile { get; set; }= string.Empty;
        [Display(Name = "عدد مرات الطباعة")]
        public int PrintCount { get; set; }
        public OrderFormat OrderFormat { get; set; }
        [Display(Name = "توصية من الشؤون العلمية")]
        public string? ScientificrRcommendation { get; set; }
        [Display(Name = "الاستمارة")]
        public string? ResFormId { get; set; }
        [Display(Name = "Order Num.")]
        public string OrderNumber { get; set; }
        [Display(Name = "Order Date.")]
        public DateTime OrderDate { get; set; }
        [Display(Name = "رقم الوصل")]
        public int InvoiceId { get; set; } 
    }

    public enum ConferenceStatus
    {
        Approved, // موافقه نهائيه من د طارق
        pending,// موافقه اولية من رسل
        Checking,// تم الرفع من الاقسام
        Rejected,// مرفوض من د طارق
        Archive,//  تم المسح
        PresidentPrint,
        PresidentAproved,
        PresidentReject,
        ITApprove,
        Finincer

    }

}
