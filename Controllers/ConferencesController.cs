using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using aspcore.Data;
using aspcore.Models;
using Microsoft.AspNetCore.Authorization;
using aspcore.Models.Shared;

namespace aspcore.Controllers
{
    [Authorize(Roles = UserType.Admin)]

    public class ConferencesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ConferencesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Conferences
        public async Task<IActionResult> Index()
        {
              return View(await _context.Conferences.Where(item => item.Status == ConferenceStatus.pending).ToListAsync());
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


        [HttpPost, ActionName("Approve")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Approve(long id)
        {
            if (_context.ResearchMUS == null)
            {
                return Problem("Entity set 'ApplicationDbContext.ResearchMUS'  is null.");
            }
            var researchMUS = await _context.Conferences.FirstAsync(item => item.ID == id && item.Status == ConferenceStatus.pending);
            if (researchMUS != null)
            {
                // researchMUS.SDGtype = ","+string.Join(',' , SDGList)+",";
                researchMUS.Status = ConferenceStatus.Approved;

                int code =1 ;
                var lastRes =  await _context.Conferences.Where(item => item.Status== ConferenceStatus.Approved).OrderByDescending(item => item.LastUpdate).FirstOrDefaultAsync();
                if (lastRes != null)
                {
                    code = lastRes.Code.Value + 1;
                }

                researchMUS.Code = code;
                researchMUS.LastUpdate = DateTime.Now;
                //researchMUS.totalMoney = TotalPrice;
                var rrts = await _context.ConferenceResearches.Where(item => item.ConferenceId == researchMUS.ID).ToListAsync();

                researchMUS.Names = String.Join(Environment.NewLine, rrts.Select(item => item.ResearcherArName).ToList());
                researchMUS.Amounts = String.Join(Environment.NewLine, rrts.Select(item => item.ResearcherMoney).ToList());
                researchMUS.Degrees = String.Join(Environment.NewLine, rrts.Select(item => item.ResearcherDeg).ToList());


                List<string> deplist = new List<string>();
                foreach (var item in rrts)
                {
                    deplist.Add(item.DepartmentTitle);

                }
                researchMUS.Departments = String.Join(Environment.NewLine, deplist);



            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
