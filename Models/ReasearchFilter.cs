namespace aspcore.Models
{
    public class ReasearchFilter
    {

        public int QuarterSelected { get; set; }

        public int ResearchType { get; set; }
        public int OpenAccessSelected { get; set; }
        public int AppliedSelected { get; set; }
        public string Name { get; set; }
        public int SDG { get; set; }
        public double ImpactFacter { get; set; }
        public string DepId { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
        public string journaltitle { get; set; }
        public int JournalType { get; set; }
        public int PublishType { get; set; }

        public bool journaltitleCheck { get; set; }
        public bool QuarterCheck { get; set; }
        public bool SDGCheck { get; set; }
        public bool TotalMoneyCheck { get; set; }
        public bool JournalCountryCheck { get; set; }
        public bool PublisherCheck { get; set; }
        public bool PublishDateCheck { get; set; }
        public bool ResearchLinkCheck { get; set; }

    }


    public class StatusViewModle
    {
        public int Id { get; set; }
        public string Name { get; set; }

    }

    public class StatusDepViewModle
    {
        public string Id { get; set; }
        public string Name { get; set; }

    }
}
