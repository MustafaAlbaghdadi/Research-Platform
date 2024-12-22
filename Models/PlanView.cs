namespace aspcore.Models
{
    public class PlanView
    {
        public int DepartmentID { get; set; }
        public string DepartmentName { get; set; }
        public int Total { get; set; }
        public int completed { get; set; }
        public int In_process { get; set; }
        public int rejected { get; set; }
    }
}
