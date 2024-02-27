using aspcore.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace aspcore.Controllers
{
    public class ApiController : Controller
    {


        public ApplicationDbContext _context { get; }


        public ApiController(ApplicationDbContext context)
        {
            _context = context;
        }


        public IActionResult Index()
        {
            return View();
        }

        [HttpGet("Api/Resarch")]
        public ActionResult Resarch()
        {


            var list = _context.ResearchMUS.Where(item => item.checkState == "0" && item.viewlvl == 1).ToList();

            return Ok(list);

        }

        [HttpGet("/Api/ResDetails/{id}")]
        public async Task<ActionResult> ResDetails([FromRoute] long id)
        {
            try
            {
                var res = await _context.ResearchMUS.FirstOrDefaultAsync(item => item.Id == id && item.openAccess == "1" && item.checkState == "0");
                res.ExtResrchDetail = null;
                res.SCOPUS_link = null;
                res.published = null;
                res.rankOutOf = null;
                res.openAccess = null;
                res.OtherResearch = null;
                res.code = null;
                res.viewlvl = 0;
                res.publisherEmail = null;
                res.SDGtype = null;
                res.Notes = null;
                res.ThanksOFcoll = null;
                res.ExtResrch = false;
                res.ExtResrch_Local = false;
                res.ExtResrch_Globl = false;
                res.LastUpDate = DateTime.Now;
                res.checkState = "";
                res.RejectReason = null;
                res.ResearchersList = null;
                res.totalMoney = null;
                res.SDGList = null;
                res.scopusHumanDepartment = null;
                res.Names = null;
                res.Amounts = null;
                res.Degrees = null;
                res.Departments = null;
                res.attachedFile1 = null;
                res.attachedFile2 = null;
                res.attachedFile3 = null;
                res.attachedFile4 = null;
                res.externalResearcher = false;
                res.GrantInfo = false;
                res.OrderNumber = null;
                res.OrderDate = DateTime.Now;
                res.OrderFile = string.Empty;

                return Ok(res);
            }
            catch
            {

                return NotFound();
            }


        }

        [HttpGet("/Api/ResDetails")]
        public async Task<ActionResult> ResDetailsList([FromQuery] string search = "")
        {
            try
            {
                var resault =await _context.ResearchMUS.Where(item => (item.openAccess == "1" && item.checkState == "0") && (item.title.Contains(search) || item.ISSNorEISSN.Contains(search) || item.journaltitle.Contains(search) || item.JournalCountry!.Contains(search))).ToListAsync();
                foreach (var res in resault)
                {
                    res.ExtResrchDetail = null;
                    res.SCOPUS_link = null;
                    res.published = null;
                    res.rankOutOf = null;
                    res.openAccess = null;
                    res.OtherResearch = null;
                    res.code = null;
                    res.viewlvl = 0;
                    res.publisherEmail = null;
                    res.SDGtype = null;
                    res.Notes = null;
                    res.ThanksOFcoll = null;
                    res.ExtResrch = false;
                    res.ExtResrch_Local = false;
                    res.ExtResrch_Globl = false;
                    res.LastUpDate = DateTime.Now;
                    res.checkState = "";
                    res.RejectReason = null;
                    res.ResearchersList = null;
                    res.totalMoney = null;
                    res.SDGList = null;
                    res.scopusHumanDepartment = null;
                    res.Names = null;
                    res.Amounts = null;
                    res.Degrees = null;
                    res.Departments = null;
                    res.attachedFile1 = null;
                    res.attachedFile2 = null;
                    res.attachedFile3 = null;
                    res.attachedFile4 = null;
                    res.externalResearcher = false;
                    res.GrantInfo = false;
                    res.OrderNumber = null;
                    res.OrderDate = DateTime.Now;
                    res.OrderFile = string.Empty;
                }
                
                
                if (string.IsNullOrWhiteSpace(search) && resault.Count >5)
                {
                    return Ok(resault.Take(5));
                }
                return Ok(resault);
            }
            catch 
            {
                return NotFound(); 
                 
            }
          

        }

    }
}
