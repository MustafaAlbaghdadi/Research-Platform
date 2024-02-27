namespace aspcore.Models.Reports
{
    public class QuartileReportModel
    {
        public int Q1 { get; set; }
        public int Q2 { get; set; }
        public int Q3 { get; set; }
        public int Q4 { get; set; }
        public List<QuartileDepartment> QuartileDepartments { get; set; }

    }
    public class QuartileDepartment
    {
        public string Title { get; set; }
        public int Q1 { get; set; }
        public int Q2 { get; set; }
        public int Q3 { get; set; }
        public int Q4 { get; set; }
        public int Id { get; internal set; }
    }

}
