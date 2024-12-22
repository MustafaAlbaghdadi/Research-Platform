using aspcore.Data;
using aspcore.Models.Reports;
using aspcore.Models.Shared;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.Intrinsics.Arm;
using System.Text;

namespace aspcore.Controllers
{
    [Authorize]

    public class ReportsController : Controller
    {
        private readonly ApplicationDbContext _context;
        public ReportsController(ApplicationDbContext context)
        {
            _context = context;

        }
        public ActionResult plan()
        {




            return View(_context.PlanResDepView.ToList());
        }


        public IActionResult Departments([FromRoute] int id)
        {
            var list = new List<DepartmentsReportModel>();

            StringBuilder sb = new StringBuilder();

            var query = _context.ResearchMUS.Where(item => item.viewlvl == 1);

            if (id > 0)
            {
                query = query.Where(item => (DateTime.Now.Month - item.pubDate.Month) + 12 * (DateTime.Now.Year - item.pubDate.Year) < id);

            }

            var deps = query.Select(item => item.Departments).ToList();
            foreach (var item in deps)
            {
                if (!string.IsNullOrWhiteSpace(item))
                {
                    sb.AppendLine(item);
                }
            }

            Dictionary<string, int> dic = new Dictionary<string, int>();

            foreach (var item in sb.ToString().Replace('\r', ' ').Split('\n'))
            {
                if (!dic.ContainsKey(item))
                {
                    dic.Add(item, 1);

                }
                else
                {
                    dic[item] += 1;

                }
            }

            foreach (var item in dic)
            {
                list.Add(new DepartmentsReportModel { Name = "(" + item.Value + ")   " + item.Key, Count = item.Value });

            }



            //foreach (var dep in _context.DepTable)
            //{
            //    int count = 0;
            //    if (id == 0)
            //    {



            //        count = (from rr in _context.RR2tabel
            //                 join recearch in _context.ResearchMUS on rr.ResearchId equals recearch.Id
            //                 where rr.ResearcherDept == dep.depname
            //                 where recearch.checkState == "0"
            //                 where recearch.viewlvl == 1
            //                 select 0).Count();

            //    }
            //    else
            //    {
            //        count = (from rr in _context.RR2tabel
            //                 join recearch in _context.ResearchMUS on rr.ResearchId equals recearch.Id
            //                 where rr.ResearcherDept == dep.depname
            //                 where recearch.checkState == "0"
            //                 where recearch.viewlvl == 1
            //                 where (DateTime.Now.Month - recearch.LastUpDate.Month) + 12 * (DateTime.Now.Year - recearch.LastUpDate.Year) < id
            //                 select 0).Count();
            //    }





            //    // count = new Random().Next(30);//todo remove fake data
            //    list.Add(new DepartmentsReportModel { Name = "(" + count + ")   " + dep.depname, Count = count });

            //}

            return View(list);
        }

        public IActionResult Quartile([FromRoute] int id = 0)
        {
            var quartile = new QuartileReportModel();

            if (id > 0)
            {
                quartile.Q1 = _context.ResearchMUS.Count(item => item.quartile == 1 && item.viewlvl == 1 && (DateTime.Now.Month - item.uploadDate.Month) + 12 * (DateTime.Now.Year - item.uploadDate.Year) < id);
                quartile.Q2 = _context.ResearchMUS.Count(item => item.quartile == 2 && item.viewlvl == 1 && (DateTime.Now.Month - item.uploadDate.Month) + 12 * (DateTime.Now.Year - item.uploadDate.Year) < id);
                quartile.Q3 = _context.ResearchMUS.Count(item => item.quartile == 3 && item.viewlvl == 1 && (DateTime.Now.Month - item.uploadDate.Month) + 12 * (DateTime.Now.Year - item.uploadDate.Year) < id);
                quartile.Q4 = _context.ResearchMUS.Count(item => item.quartile == 4 && item.viewlvl == 1 && (DateTime.Now.Month - item.uploadDate.Month) + 12 * (DateTime.Now.Year - item.uploadDate.Year) < id);

                //todo remove fake data
                //quartile.Q1 = 20;
                //quartile.Q2 = 26;
                //quartile.Q3 = 20;
                //quartile.Q4 = 42;
                quartile.QuartileDepartments = new List<QuartileDepartment>();
                foreach (var item in _context.DepTable)
                {
                    var rrt = from rr in _context.RR2tabel join recearch in _context.ResearchMUS on rr.ResearchId equals recearch.Id where rr.ResearcherDept == item.depname where recearch.viewlvl == 1 where (DateTime.Now.Month - recearch.uploadDate.Month) + 12 * (DateTime.Now.Year - recearch.uploadDate.Year) < id select new { rrt = rr, quartile = recearch.quartile };


                    quartile.QuartileDepartments.Add(new QuartileDepartment
                    {
                        Id = item.Id,
                        Title = item.depname,//todo remove fake data
                        Q1 = rrt.Count(item => item.quartile == 1),
                        Q2 = rrt.Count(item => item.quartile == 2),
                        Q3 = rrt.Count(item => item.quartile == 3),
                        Q4 = rrt.Count(item => item.quartile == 4),

                    });
                }
            }
            else
            {
                quartile.Q1 = _context.ResearchMUS.Count(item => item.quartile == 1 && item.viewlvl == 1);
                quartile.Q2 = _context.ResearchMUS.Count(item => item.quartile == 2 && item.viewlvl == 1);
                quartile.Q3 = _context.ResearchMUS.Count(item => item.quartile == 3 && item.viewlvl == 1);
                quartile.Q4 = _context.ResearchMUS.Count(item => item.quartile == 4 && item.viewlvl == 1);

                //todo remove fake data
                //quartile.Q1 = 20;
                //quartile.Q2 = 26;
                //quartile.Q3 = 20;
                //quartile.Q4 = 42;
                quartile.QuartileDepartments = new List<QuartileDepartment>();
                foreach (var item in _context.DepTable)
                {
                    var rrt = from rr in _context.RR2tabel join recearch in _context.ResearchMUS on rr.ResearchId equals recearch.Id where rr.ResearcherDept == item.depname where recearch.viewlvl == 1 select new { rrt = rr, quartile = recearch.quartile };


                    quartile.QuartileDepartments.Add(new QuartileDepartment
                    {
                        Id = item.Id,
                        Title = item.depname,//todo remove fake data
                        Q1 = rrt.Count(item => item.quartile == 1),
                        Q2 = rrt.Count(item => item.quartile == 2),
                        Q3 = rrt.Count(item => item.quartile == 3),
                        Q4 = rrt.Count(item => item.quartile == 4),

                    });
                }
            }


            return View(quartile);
        }


        public IActionResult SDG([FromRoute] int id)
        {
            var list = new List<DepartmentsReportModel>();
            for (int sdg = 1; sdg <= 17; sdg++)
            {

                int count = 0;
                if (id == 0)
                {
                    count = _context.ResearchMUS.Count(item => item.SDGtype.Contains("," + sdg + ",") && item.viewlvl == 1);

                }
                else
                {
                    count = _context.ResearchMUS.Count(item =>

                    (DateTime.Now.Month - item.LastUpDate.Month) + 12 * (DateTime.Now.Year - item.LastUpDate.Year) < id
                    && item.SDGtype.Contains("," + sdg + ",")
                    && item.viewlvl == 1);
                }





                // count = new Random().Next(30);//todo remove fake data
                list.Add(new DepartmentsReportModel { Name = "(" + count + ")   " + GetSdgTitle(sdg), Count = count });

            }

            return View(list);
        }


        public string GetSdgTitle(int sdg)
        {
            switch (sdg)
            {
                case 1:
                    return "الهدف 1– القضاء على الفقر";
                case 2:
                    return "الهدف 2 – القضاء التام على الجوع";
                case 3:
                    return "الهدف 3 – الصحة الجيدة والرفاه";
                case 4:
                    return "الهدف 4 – التعليم الجيد";
                case 5:
                    return "الهدف 5 – المساواة بين الجنسين";
                case 6:
                    return "الهدف 6 – المياه النظيفة والنظافة الصحية";
                case 7:
                    return "الهدف 7– طاقة نظيفة وبأسعار معقولة";
                case 8:
                    return "الهدف 8– العمل اللائق ونمو الاقتصاد";
                case 9:
                    return "الهدف 9– الصناعة والابتكار والبنية التحتية";
                case 10:
                    return "الهدف 10– الحد من أوجه عدم المساواة";
                case 11:
                    return "الهدف 11– مدن ومجتمعات محلية مستدامة";
                case 12:
                    return "الهدف 12– الاستهلاك والإنتاج المسؤولان";
                case 13:
                    return "الهدف 13– العمل المناخي";
                case 14:
                    return "الهدف 14– الحياة تحت الماء";
                case 15:
                    return "الهدف 15– الحياة في البرّ";
                case 16:
                    return "الهدف 16– السلام والعدالة والمؤسسات القوية";
                case 17:
                    return "الهدف 17– عقد الشراكة لتحقيق الأهداف";
            }
            return "";
        }
    }
}
