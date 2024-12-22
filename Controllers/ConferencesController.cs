using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using aspcore.Data;
using aspcore.Models;
using Microsoft.AspNetCore.Authorization;
using aspcore.Models.Shared;

namespace aspcore.Controllers
{
    [Authorize(Roles = $"{UserType.Admin},{UserType.President},{UserType.ITApprove},{UserType.Finance}")]

    public class ConferencesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ConferencesController(ApplicationDbContext context)
        {
            _context = context;
        }
        public static string AddCommaBefore000(string number)
        {
            string numberString = number;
            int length = numberString.Length;

            // Insert comma before every "000" starting from the end
            for (int i = length - 3; i > 0; i -= 3)
            {
                numberString = numberString.Insert(i, ",");
            }

            return numberString;
        }

        // GET: Conferences
        public async Task<IActionResult> Index([FromQuery] int select = 1)
        {
            List<Conference> list = new List<Conference>();

            //if (User.IsInRole(UserType.President))
            //{
            //    list = await _context.Conferences.Where(item => item.Status == ConferenceStatus.PresidentPrint).ToListAsync();
            //    ViewBag.TotalAmount = AddCommaBefore000(list.Sum(item => item.TotalAmount).ToString());

            //    return View(list);
            //}

            //if (User.IsInRole(UserType.ITApprove))
            //{
            //    list = await _context.Conferences.Where(item => item.Status == ConferenceStatus.ITApprove).ToListAsync();
            //    ViewBag.TotalAmount = AddCommaBefore000(list.Sum(item => item.TotalAmount).ToString());

            //    return View(list);
            //}


            if (await _context.Conferences.AnyAsync(item => string.IsNullOrWhiteSpace(item.Names)))
            {
                foreach (var confernce in _context.Conferences.Where(item => string.IsNullOrWhiteSpace(item.Names)))
                {
                    var conferenceResearches = await _context.ConferenceResearches.Where(item => item.ConferenceId == confernce.ID).OrderBy(item => item.Sequence).ToListAsync();
                    confernce.Names = String.Join(Environment.NewLine, conferenceResearches.Select(item => item.ResearcherArName).ToList());
                    confernce.Amounts = String.Join(Environment.NewLine, conferenceResearches.Select(item => item.ResearcherMoney).ToList());
                    confernce.Degrees = String.Join(Environment.NewLine, conferenceResearches.Select(item => item.ResearcherDeg).ToList());
                    List<string> deplist = new List<string>();
                    foreach (var item in conferenceResearches)
                    {
                        deplist.Add(item.DepartmentTitle);

                    }
                    confernce.Departments = String.Join(Environment.NewLine, deplist);
                }
                _context.SaveChanges();
            }
            if (User.IsInRole(UserType.President) && select == 1)
            {
                select = 5;
            }
            else if (User.IsInRole(UserType.ITApprove) && select == 1)
            {
                select = 8;
            }
            else if (User.IsInRole(UserType.Finance) && select == 1)
            {
                select = 9;
            }

            list = await _context.Conferences.Where(item => item.Status == (ConferenceStatus)select).ToListAsync();
            ViewBag.TotalAmount = AddCommaBefore000(list.Sum(item => item.TotalAmount).ToString());
            ViewBag.TotalAmountCheckout = AddCommaBefore000(list.Where(item => item.OrderFormat == OrderFormat.ScopusCheckout).Sum(item => item.TotalAmount ).ToString());
            ViewBag.TotalAmountSettlement = AddCommaBefore000(list.Where(item => item.OrderFormat == OrderFormat.ScopusSettlement).Sum(item => item.TotalAmount).ToString());
            return View(list);

        }

        // GET: Conferences/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null || _context.Conferences == null)
            {
                return NotFound();
            }

            var conference = await _context.Conferences
                .FirstOrDefaultAsync(m => m.ID == id);

            if (conference == null)
            {
                return NotFound();
            }


            var conferenceResearches = _context.ConferenceResearches.Where(item => item.ConferenceId == conference.ID);
            if (conferenceResearches.Any())
            {
                conference.ConferenceResearchesList = conferenceResearches.ToList();
            }




            if (string.IsNullOrWhiteSpace(conference.Departments))
            {
                var rrts = await _context.ConferenceResearches.Where(item => item.ConferenceId == conference.ID).ToListAsync();
                conference.Names = String.Join(Environment.NewLine, rrts.Select(item => item.ResearcherArName).ToList());
                conference.Amounts = String.Join(Environment.NewLine, rrts.Select(item => item.ResearcherMoney).ToList());
                conference.Degrees = String.Join(Environment.NewLine, rrts.Select(item => item.ResearcherDeg).ToList());
                List<string> deplist = new List<string>();
                foreach (var item in rrts)
                {
                    deplist.Add(item.DepartmentTitle);

                }
                conference.Departments = String.Join(Environment.NewLine, deplist);

                _context.SaveChanges();
            }




            return View(conference);
        }

        // GET: Conferences/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Conferences/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Code,ResearchTitle,MainFile,PublishDate,Title,Address,Publisher,Type,Attach1,Attach2,PriviteCollege,PublicCollege,GlobalCollege,Acknowledge,TotalAmount,CreateDate,LastUpdate,Status,RejectReson,UploaderEmail,QRImage,ScopusLink,ResearchLink")] Conference conference)
        {
            if (ModelState.IsValid)
            {
                _context.Add(conference);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(conference);
        }

        // GET: Conferences/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null || _context.Conferences == null)
            {
                return NotFound();
            }

            var conference = await _context.Conferences.FindAsync(id);
            if (conference == null)
            {
                return NotFound();
            }
            return View(conference);
        }

        // POST: Conferences/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("ID,Code,ResearchTitle,MainFile,PublishDate,Title,Address,Publisher,Type,Attach1,Attach2,PriviteCollege,PublicCollege,GlobalCollege,Acknowledge,TotalAmount,CreateDate,LastUpdate,Status,RejectReson,UploaderEmail,QRImage,ScopusLink,ResearchLink")] Conference conference)
        {
            if (id != conference.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(conference);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ConferenceExists(conference.ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(conference);
        }

        // GET: Conferences/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null || _context.Conferences == null)
            {
                return NotFound();
            }

            var conference = await _context.Conferences
                .FirstOrDefaultAsync(m => m.ID == id);
            if (conference == null)
            {
                return NotFound();
            }

            return View(conference);
        }
        // POST: ResearchMUS/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id, string RejectReson)
        {
            if (_context.Conferences == null)
            {
                return Problem("Entity set 'ApplicationDbContext.ResearchMUS'  is null.");
            }

            var researchMUS = await _context.Conferences.FirstAsync(item => item.ID == id);
            if (researchMUS != null)
            {
                researchMUS.Status = ConferenceStatus.Rejected;
                researchMUS.RejectReson = RejectReson;
                //_context.ResearchMUS.Remove(researchMUS);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        private bool ConferenceExists(long id)
        {
            return _context.Conferences.Any(e => e.ID == id);
        }


        //[HttpPost, ActionName("Approve")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Approve(long id)
        //{
        //    if (_context.ResearchMUS == null)
        //    {
        //        return Problem("Entity set 'ApplicationDbContext.ResearchMUS'  is null.");
        //    }
        //    var researchMUS = await _context.Conferences.FirstAsync(item => item.ID == id && item.Status == ConferenceStatus.pending);
        //    if (researchMUS != null)
        //    {
        //        // researchMUS.SDGtype = ","+string.Join(',' , SDGList)+",";
        //        researchMUS.Status = ConferenceStatus.Approved;

        //        int code =1 ;
        //        var lastRes =  await _context.Conferences.Where(item => item.Status== ConferenceStatus.Approved).OrderByDescending(item => item.LastUpdate).FirstOrDefaultAsync();
        //        if (lastRes != null)
        //        {
        //            code = lastRes.Code.Value + 1;
        //        }

        //        researchMUS.Code = code;
        //        researchMUS.LastUpdate = DateTime.Now;
        //        //researchMUS.totalMoney = TotalPrice;
        //        var rrts = await _context.ConferenceResearches.Where(item => item.ConferenceId == researchMUS.ID).ToListAsync();

        //        researchMUS.Names = String.Join(Environment.NewLine, rrts.Select(item => item.ResearcherArName).ToList());
        //        researchMUS.Amounts = String.Join(Environment.NewLine, rrts.Select(item => item.ResearcherMoney).ToList());
        //        researchMUS.Degrees = String.Join(Environment.NewLine, rrts.Select(item => item.ResearcherDeg).ToList());


        //        List<string> deplist = new List<string>();
        //        foreach (var item in rrts)
        //        {
        //            deplist.Add(item.DepartmentTitle);

        //        }
        //        researchMUS.Departments = String.Join(Environment.NewLine, deplist);



        //    }

        //    await _context.SaveChangesAsync();
        //    return RedirectToAction(nameof(Index));
        //}

        //////////////////////////////////////////////////////

        [HttpPost, ActionName("DirectApprove")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DirectApprove(long id)
        {

            string OrderUrl = "https://resadmin.uomus.edu.iq";//todo 
            if (_context.Conferences == null)
            {
                return Problem("Entity set 'ApplicationDbContext.ResearchMUS'  is null.");
            }




            var conference = await _context.Conferences.FirstAsync(item => item.ID == id);
            if (conference != null)
            {




                conference.Status = ConferenceStatus.Approved;
                conference.LastUpdate = DateTime.Now;

            }

            await _context.SaveChangesAsync();
            try
            {
                System.Net.WebClient wc = new System.Net.WebClient();
                wc.DownloadString(conference.ResFormId + $"?secret=kjhadbfkgdbfhgadfgadbfgadfkjasdkvbhc&status=5&it=Direct");

            }
            catch
            {


            }

            return RedirectToAction(nameof(Index));
        }



        // POST: ResearchMUS/Delete/5
        [HttpPost, ActionName("Approve")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Approve(long id, IFormFile OrderFile, string OrderNumber, DateTime OrderDate)
        {

            string OrderUrl = "https://resadmin.uomus.edu.iq";//todo 
            if (_context.Conferences == null || OrderFile == null)
            {
                return Problem("Entity set 'ApplicationDbContext.ResearchMUS'  is null.");
            }

            if (OrderFile.ContentType != "application/pdf")
            {
                return BadRequest();
            }

            string rootDir = System.IO.Directory.GetCurrentDirectory() + @"\Files\";
            if (!System.IO.Directory.Exists(rootDir))
            {
                System.IO.Directory.CreateDirectory(rootDir);
            }
            string fileName = Guid.NewGuid().ToString() + ".pdf";
            string filePath = Path.Combine(rootDir, fileName);


            using (Stream fileStream = new FileStream(filePath, FileMode.Create, FileAccess.Write))
            {
                OrderFile.CopyTo(fileStream);
            }

            string relativePath = "/Files/" + fileName;
            OrderUrl += relativePath;

            var researchMUS = await _context.Conferences.FirstAsync(item => item.ID == id);
            if (researchMUS != null)
            {

                researchMUS.OrderFile = relativePath;

                // researchMUS.SDGtype = ","+string.Join(',' , SDGList)+",";
                researchMUS.Status = ConferenceStatus.Approved;
                researchMUS.LastUpdate = DateTime.Now;
                researchMUS.OrderDate = OrderDate.Date;
                researchMUS.OrderNumber = OrderNumber;

            }

            await _context.SaveChangesAsync();
            try
            {
                System.Net.WebClient wc = new System.Net.WebClient();
                  wc.DownloadString(researchMUS.ResFormId + $"?secret=kjhadbfkgdbfhgadfgadbfgadfkjasdkvbhc&status=5&orderurl={OrderUrl}");

            }
            catch
            {


            }

            return RedirectToAction(nameof(Index));
        }


        [HttpPost, ActionName("ITApproveMustafa")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ITApproveMustafa(Conference research)
        {
            if (_context.Conferences == null)
            {
                return Problem("Entity set 'ApplicationDbContext.ResearchMUS'  is null.");
            }



            var researchMUS = await _context.Conferences.FirstAsync(item => item.ID == research.ID);
            if (researchMUS != null)
            {
                // researchMUS.SDGtype = ","+string.Join(',' , SDGList)+",";
                researchMUS.Status = ConferenceStatus.ITApprove;
                researchMUS.PrintCount = 0;
                researchMUS.LastUpdate = DateTime.Now;
                //researchMUS.totalMoney = TotalPrice;

                researchMUS.TotalAmount = research.TotalAmount;
                researchMUS.OrderFormat = research.OrderFormat;
            }

            if (string.IsNullOrWhiteSpace(researchMUS.ResFormId))
            {
                researchMUS.ResFormId = research.ResFormId;

            }

            await _context.SaveChangesAsync();
            try
            {
                System.Net.WebClient wc = new System.Net.WebClient();
                wc.DownloadString(researchMUS.ResFormId + $"?secret=kjhadbfkgdbfhgadfgadbfgadfkjasdkvbhc&status=4");

            }
            catch
            {
                return RedirectPermanent(researchMUS.ResFormId + $"?secret=kjhadbfkgdbfhgadfgadbfgadfkjasdkvbhc&status=4");
            }
            return RedirectToAction(nameof(Index));
        }
        [HttpPost, ActionName("ITApprove")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ITApprove(Conference research)
        {
            if (_context.Conferences == null)
            {
                return Problem("Entity set 'ApplicationDbContext.ResearchMUS'  is null.");
            }



            var researchMUS = await _context.Conferences.FirstAsync(item => item.ID == research.ID);
            if (researchMUS != null)
            {
                researchMUS.Status = ConferenceStatus.PresidentPrint;
                researchMUS.PrintCount = 0;
                researchMUS.LastUpdate = DateTime.Now;
            }


            await _context.SaveChangesAsync();
            try
            {
                System.Net.WebClient wc = new System.Net.WebClient();
                wc.DownloadString(researchMUS.ResFormId + $"?secret=kjhadbfkgdbfhgadfgadbfgadfkjasdkvbhc&status=4");

            }
            catch
            {
                return RedirectPermanent(researchMUS.ResFormId + $"?secret=kjhadbfkgdbfhgadfgadbfgadfkjasdkvbhc&status=4");
            }
            return RedirectToAction(nameof(Index));
        }



        public async Task<ActionResult> PrintAsync(long id)
        {
            var researchMUS = await _context.Conferences.FirstAsync(item => item.ID == id);
            researchMUS.PrintCount += 1;
            _context.SaveChanges();
            switch (researchMUS.OrderFormat)
            {
                case OrderFormat.ScopusCheckout:
                    return Redirect("/Conferences/OrderPrint/" + id);
                case OrderFormat.ScopusSettlement:
                    return Redirect("/Conferences/ScopusSettlementPrint/" + id);
                default:
                    break;
            }
            return View();
        }


        public async Task<ActionResult> OrderPrintAsync(long id)
        {
            var researchMUS = await _context.Conferences.FirstAsync(item => item.ID == id);

            return View(researchMUS);
        }

        public async Task<ActionResult> ScopusSettlementPrintAsync(long id)
        {
            var researchMUS = await _context.Conferences.FirstAsync(item => item.ID == id);

            return View(researchMUS);
        }

        public async Task<ActionResult> PresidentAprove(long id)
        {
            var researchMUS = await _context.Conferences.FirstAsync(item => item.ID == id);
            researchMUS.Status = ConferenceStatus.PresidentAproved;
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        public async Task<ActionResult> presednetReject(long id, string rejectReason)
        {
            var researchMUS = await _context.Conferences.FirstAsync(item => item.ID == id);
            researchMUS.RejectReson = rejectReason;
            researchMUS.Status = ConferenceStatus.PresidentReject;
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }


    }
}
