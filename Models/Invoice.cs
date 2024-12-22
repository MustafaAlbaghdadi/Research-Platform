using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace aspcore.Models
{
    public class Invoice
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int Id { get; set; }
        public string Name { get; set; }
        public long Amount { get; set; }
        public string AmountString { get; set; }
        public string OrderNumber { get; set; }
        public DateTime OrderDate { get; set; }
        public ReaserchType ReaserchType { get; set; }



    }
    public enum ReaserchType
    {
        Scopus,
        Conference
    }
}
