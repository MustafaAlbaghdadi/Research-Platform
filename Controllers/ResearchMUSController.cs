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
    public class ResearchMUSController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ResearchMUSController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: ResearchMUS
        public async Task<IActionResult> Index()
        {
            return View(await _context.ResearchMUS.Where(item => item.checkState == "1" && item.viewlvl != 0).ToListAsync());
        }



        public async Task<IActionResult> Indexing([FromRoute] long? id)
        {
            var res = await _context.ResearchMUS.FirstOrDefaultAsync(item => item.Id == id);
            res.published = "1";
            await _context.SaveChangesAsync();
            return Redirect("/ResearchMUS/ArchiveReview/" + id);
        }


        public async Task<IActionResult> Archive()
        {
            var visaFilter = SetFilterValue();

            return View(await qetQuery(visaFilter));
        }


        [HttpPost]
        public async Task<IActionResult> Archive(ReasearchFilter visaFilter)
        {

            visaFilter = SetFilterValue(visaFilter);

            return View(await qetQuery(visaFilter));

        }
        public async Task<List<ResearchMUS>> qetQuery(ReasearchFilter visaFilter)
        {
            var query = _context.ResearchMUS.Where(item => item.viewlvl == 1);

            if (visaFilter.QuarterSelected > 0)
            {
                query = query.Where(item => item.quartile == visaFilter.QuarterSelected);
            }


            if (visaFilter.ResearchType > 0)
            {

                switch (visaFilter.ResearchType)
                {
                    case 1:
                        query = query.Where(item => item.ExtResrch);
                        break;
                    case 2:
                        query = query.Where(item => item.ExtResrch_Local);
                        break;
                    case 3:
                        query = query.Where(item => item.ExtResrch_Globl);
                        break;
                }
            }

            if (visaFilter.OpenAccessSelected > 0)
            {
                switch (visaFilter.OpenAccessSelected)
                {
                    case 1:
                        query = query.Where(item => item.openAccess.ToLower().Trim() == "1");
                        break;
                    case 2:
                        query = query.Where(item => item.openAccess.ToLower().Trim() == "0");
                        break;

                }
            }
            if (visaFilter.AppliedSelected > 0)
            {
                switch (visaFilter.AppliedSelected)
                {
                    case 1:
                        query = query.Where(item => item.appledPaper.ToLower().Trim() == "1");
                        break;
                    case 2:
                        query = query.Where(item => item.appledPaper.ToLower().Trim() == "0");
                        break;
                }
            }
            if (visaFilter.SDG > 0)
            {
                switch (visaFilter.SDG)
                {
                    case 1:
                        query = query.Where(item => item.SDGtype != "0");
                        break;
                    default:
                        query = query.Where(item => item.SDGtype.Contains("," + (visaFilter.SDG - 1) + ","));
                        break;
                }
            }
            if (visaFilter.ImpactFacter > 0)
            {
                query = query.Where(item => item.ImpactFacter >= visaFilter.ImpactFacter);
            }
            query = query.Where(item => item.uploadDate >= visaFilter.FromDate && item.uploadDate <= visaFilter.ToDate);


            if (!string.IsNullOrWhiteSpace(visaFilter.journaltitle))
            {
                query = query.Where(item => item.journaltitle.Contains(visaFilter.journaltitle));
            }

            if (visaFilter.JournalType > 0)
            {
                switch (visaFilter.JournalType)
                {
                    case 1:
                        query = query.Where(item => item.scopas.Value);
                        break;
                    case 2:
                        query = query.Where(item => item.clarivate);
                        break;
                    case 3:
                        query = query.Where(item => item.clarivate && item.scopas.Value);
                        break;

                }
            }

            if (visaFilter.PublishType > 0)
            {
                switch (visaFilter.PublishType)
                {
                    case 1:
                        query = query.Where(item => item.published == "0");
                        break;
                    case 2:
                        query = query.Where(item => item.published == "1");
                        break;


                }
            }



            if (!string.IsNullOrWhiteSpace(visaFilter.DepId) && visaFilter.DepId != "All")
            {
                query = query.Where(item => item.Departments.Contains(visaFilter.DepId));
            }




            if (!string.IsNullOrWhiteSpace(visaFilter.Name))
            {
                query = query.Where(item => item.Names.Contains(visaFilter.Name));
            }



            var researchMUs = query.OrderByDescending(item => item.LastUpDate).ToList();

            return researchMUs;
        }

        private ReasearchFilter SetFilterValue(ReasearchFilter visaFilter = null)
        {
            if (visaFilter == null)
            {
                visaFilter = new ReasearchFilter();
            }

            List<StatusDepViewModle> DepStatusViewModles = new List<StatusDepViewModle>();

            foreach (var dep in _context.DepTable)
            {
                DepStatusViewModles.Add(new StatusDepViewModle() { Id = dep.depname, Name = dep.depname });

            }


            List<StatusViewModle> QuartileStatusViewModles = new List<StatusViewModle>
            {
                new StatusViewModle() { Id = 1, Name = "Q1"  },
                new StatusViewModle() { Id = 2, Name = "Q2"  },
                new StatusViewModle() { Id = 3, Name =  "Q3"  },
                new StatusViewModle() { Id = 4, Name =  "Q4"  }
            };
            List<StatusViewModle> ResearchTypeStatusViewModles = new List<StatusViewModle>
            {
                new StatusViewModle() { Id = 1, Name = "External Research"  },
                new StatusViewModle() { Id = 2, Name = "Local Research"  },
                new StatusViewModle() { Id = 3, Name =  "Global Research"  },
            };
            List<StatusViewModle> JournalType = new List<StatusViewModle>
            {
                new StatusViewModle() { Id = 1, Name = "Scopus"  },
                new StatusViewModle() { Id = 2, Name = "Clarivate"  },
                new StatusViewModle() { Id = 3, Name =  "Scopus and Clarivate"  },
            };
            List<StatusViewModle> OpenAccessStatusViewModles = new List<StatusViewModle>
            {
                new StatusViewModle() { Id = 1, Name = "yes"  },
                new StatusViewModle() { Id = 2, Name = "no"  },
            };
            List<StatusViewModle> PublishTypeStatusViewModles = new List<StatusViewModle>
            {
                new StatusViewModle() { Id = 1, Name = "منشور"  },
                new StatusViewModle() { Id = 2, Name = "منشور ومفهرس"  },
            };
            List<StatusViewModle> SDGStatusViewModles = new List<StatusViewModle>
            {
                new StatusViewModle() { Id = 1, Name = "yes"  },
                new StatusViewModle() { Id = 2, Name = "1"  },
                new StatusViewModle() { Id = 3, Name = "2"  },
                new StatusViewModle() { Id = 4, Name = "3"  },
                new StatusViewModle() { Id = 5, Name = "4"  },
                new StatusViewModle() { Id = 6, Name = "5"  },
                new StatusViewModle() { Id = 7, Name = "6"  },
                new StatusViewModle() { Id = 8, Name = "7"  },
                new StatusViewModle() { Id = 9, Name = "8"  },
                new StatusViewModle() { Id = 10, Name = "9"  },
                new StatusViewModle() { Id = 11, Name = "10"  },
                new StatusViewModle() { Id = 12, Name = "11"  },
                new StatusViewModle() { Id = 13, Name = "12"  },
                new StatusViewModle() { Id = 14, Name = "13"  },
                new StatusViewModle() { Id = 15, Name = "14"  },
                new StatusViewModle() { Id = 16, Name = "15"  },
                new StatusViewModle() { Id = 17, Name = "16"  },
                new StatusViewModle() { Id = 18, Name = "17"  },
            };
            if ((DateTime.Now - visaFilter.FromDate).TotalDays > 5000)
            {
                visaFilter.FromDate = DateTime.Now.AddDays(-1);
            }
            if ((DateTime.Now - visaFilter.ToDate).TotalDays > 5000)
            {
                visaFilter.ToDate = DateTime.Now;
            }



            //ViewData["Agencies"] = new SelectList(_context.Agencies, "Id", "Name", visaFilter.AgencySelected);
            //ViewData["VisaType"] = new SelectList(_context.VisaTypes, "Id", "Name", visaFilter.VisaTypeSelected);
            //ViewData["Suppliers"] = new SelectList(_context.Suppliers, "Id", "Name", visaFilter.SupplierSelected);
            ViewData["Dep"] = new SelectList(DepStatusViewModles, "Id", "Name", visaFilter.DepId);
            ViewData["Quartile"] = new SelectList(QuartileStatusViewModles, "Id", "Name", visaFilter.QuarterSelected);
            ViewData["ResearchType"] = new SelectList(ResearchTypeStatusViewModles, "Id", "Name", visaFilter.ResearchType);
            ViewData["OpenAccessSelected"] = new SelectList(OpenAccessStatusViewModles, "Id", "Name", visaFilter.OpenAccessSelected);
            ViewData["AppliedSelected"] = new SelectList(OpenAccessStatusViewModles, "Id", "Name", visaFilter.AppliedSelected);
            ViewData["SDG"] = new SelectList(SDGStatusViewModles, "Id", "Name", visaFilter.SDG);
            ViewData["Name"] = visaFilter.Name;
            ViewData["ImpactFacter"] = visaFilter.ImpactFacter;
            ViewData["fromDate"] = visaFilter.FromDate.Year + "-" + ToWDigitDate(visaFilter.FromDate.Month) + "-" + ToWDigitDate(visaFilter.FromDate.Day);
            ViewData["toDate"] = visaFilter.ToDate.Year + "-" + ToWDigitDate(visaFilter.ToDate.Month) + "-" + ToWDigitDate(visaFilter.ToDate.Day);

            ViewData["journaltitle"] = visaFilter.journaltitle;
            ViewData["journaltitleCheck"] = visaFilter.journaltitleCheck;
            ViewData["QuarterCheck"] = visaFilter.QuarterCheck;
            ViewData["SDGCheck"] = visaFilter.SDGCheck;
            ViewData["TotalMoneyCheck"] = visaFilter.TotalMoneyCheck;
            ViewData["JournalCountryCheck"] = visaFilter.JournalCountryCheck;
            ViewData["PublisherCheck"] = visaFilter.PublisherCheck;
            ViewData["PublishDateCheck"] = visaFilter.PublishDateCheck;
            ViewData["ResearchLinkCheck"] = visaFilter.ResearchLinkCheck;
            ViewData["JournalType"] = new SelectList(JournalType, "Id", "Name", visaFilter.JournalType); ;
            ViewData["PublishType"] = new SelectList(PublishTypeStatusViewModles, "Id", "Name", visaFilter.PublishType); ;


            return visaFilter;
        }

        private string ToWDigitDate(int num)
        {
            string value = "";
            if (num < 10)
            {
                value = "0" + num;

            }
            else
            {
                value = num.ToString();
            }
            return value;
        }



        // GET: ResearchMUS/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null || _context.ResearchMUS == null)
            {
                return NotFound();
            }

            var researchMUS = await _context.ResearchMUS
                .FirstOrDefaultAsync(m => m.Id == id && m.viewlvl == 1);
            if (researchMUS == null)
            {
                return NotFound();
            }

            return View(researchMUS);
        }

        // GET: ResearchMUS/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ResearchMUS/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("title,link,fileRes,published,pubDate,ISSNorEISSN,journaltitle,journalurl,publisher,quartile,citeScore,scopusSubSubjectArea,rank,rankOutOf,openAccess,OtherResearch,appledPaper,code,uploadDate,scopas,clarivate,viewlvl,publisherEmail,SDGtype,Notes,ThanksOFcoll,ImpactFacter,ExtResrch,ExtResrch_Local,ExtResrch_Globl,QRimage,LastUpDate")] ResearchMUS researchMUS)
        {
            if (ModelState.IsValid)
            {
                researchMUS.Id = 123;
                _context.Add(researchMUS);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(researchMUS);
        }

        // GET: ResearchMUS/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null || _context.ResearchMUS == null)
            {
                return NotFound();
            }

            var researchMUS = await _context.ResearchMUS.FirstAsync(item => item.Id == id);
            if (researchMUS == null)
            {
                return NotFound();
            }
            return View(researchMUS);
        }

        // POST: ResearchMUS/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("Id,title,link,fileRes,published,pubDate,ISSNorEISSN,journaltitle,journalurl,publisher,quartile,citeScore,scopusSubSubjectArea,rank,rankOutOf,openAccess,OtherResearch,appledPaper,code,uploadDate,scopas,clarivate,viewlvl,publisherEmail,SDGtype,Notes,ThanksOFcoll,ImpactFacter,ExtResrch,ExtResrch_Local,ExtResrch_Globl,QRimage,LastUpDate")] ResearchMUS researchMUS)
        {
            if (id != researchMUS.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(researchMUS);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ResearchMUSExists(researchMUS.Id))
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
            return View(researchMUS);
        }

        // GET: ResearchMUS/Review/5
        public async Task<IActionResult> Review(long? id)
        {
            if (id == null || _context.ResearchMUS == null)
            {
                return NotFound();
            }

            var researchMUS = await _context.ResearchMUS
                .FirstOrDefaultAsync(m => m.Id == id && m.viewlvl == 1);
            var Researchers = from relTabel in _context.RR2tabel where relTabel.ResearchId == researchMUS.Id select relTabel;
            if (Researchers.Any())
            {
                var ResearchersList = Researchers.ToList();
                researchMUS.ResearchersList = ResearchersList;
            }

            if (researchMUS == null)
            {
                return NotFound();
            }

            return View(researchMUS);
        }     // GET: ResearchMUS/ArchiveReview/5
        public async Task<IActionResult> ArchiveReview(long? id)
        {
            if (id == null || _context.ResearchMUS == null)
            {
                return NotFound();
            }

            var researchMUS = await _context.ResearchMUS
                .FirstOrDefaultAsync(m => m.Id == id && m.viewlvl == 1);
            var Researchers = from relTabel in _context.RR2tabel where relTabel.ResearchId == researchMUS.Id select relTabel;
            if (Researchers.Any())
            {
                var ResearchersList = Researchers.ToList();
                researchMUS.ResearchersList = ResearchersList;
            }

            if (researchMUS == null)
            {
                return NotFound();
            }

            return View(researchMUS);
        }

        // POST: ResearchMUS/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id, string RejectReason)
        {
            if (_context.ResearchMUS == null)
            {
                return Problem("Entity set 'ApplicationDbContext.ResearchMUS'  is null.");
            }
            var researchMUS = await _context.ResearchMUS.FirstAsync(item => item.Id == id);
            if (researchMUS != null)
            {
                researchMUS.checkState = "3";
                researchMUS.RejectReason = RejectReason;
                //_context.ResearchMUS.Remove(researchMUS);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }



        // POST: ResearchMUS/Delete/5
        [HttpPost, ActionName("Approve")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Approve(long id)
        {
            if (_context.ResearchMUS == null)
            {
                return Problem("Entity set 'ApplicationDbContext.ResearchMUS'  is null.");
            }
            //foreach (var researchMUS in _context.ResearchMUS.Where(item => item.viewlvl == 1).ToList())
            //{
            //    researchMUS.checkState = "0";
            //    researchMUS.LastUpDate = DateTime.Now;
            //    //researchMUS.totalMoney = TotalPrice;
            //    var rrts = await _context.RR2tabel.Where(item => item.ResearchId == researchMUS.Id).ToListAsync();
            //    researchMUS.Names = String.Join(Environment.NewLine, rrts.Select(item => item.ResearcherArName).ToList());
            //    researchMUS.Amounts = String.Join(Environment.NewLine, rrts.Select(item => item.ResearcherMoney).ToList());
            //    researchMUS.Degrees = String.Join(Environment.NewLine, rrts.Select(item => item.ResearcherDeg).ToList());


            //    List<string> deplist = new List<string>();
            //    foreach (var item in rrts)
            //    {
            //        deplist.Add(item.ResearcherDept);

            //    }
            //    researchMUS.Departments = String.Join(Environment.NewLine, deplist);
            //}


            var researchMUS = await _context.ResearchMUS.FirstAsync(item => item.Id == id && item.viewlvl == 1);
            if (researchMUS != null)
            {
                // researchMUS.SDGtype = ","+string.Join(',' , SDGList)+",";
                researchMUS.checkState = "0";
                researchMUS.LastUpDate = DateTime.Now;
                //researchMUS.totalMoney = TotalPrice;
                var rrts = await _context.RR2tabel.Where(item => item.ResearchId == researchMUS.Id).ToListAsync();
                researchMUS.Names = String.Join(Environment.NewLine, rrts.Select(item => item.ResearcherArName).ToList());
                researchMUS.Amounts = String.Join(Environment.NewLine, rrts.Select(item => item.ResearcherMoney).ToList());
                researchMUS.Degrees = String.Join(Environment.NewLine, rrts.Select(item => item.ResearcherDeg).ToList());


                List<string> deplist = new List<string>();
                foreach (var item in rrts)
                {
                    deplist.Add(item.ResearcherDept);

                }
                researchMUS.Departments = String.Join(Environment.NewLine, deplist);



            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ResearchMUSExists(long id)
        {
            return (_context.ResearchMUS?.Any(e => e.Id == id && e.viewlvl == 1)).GetValueOrDefault();
        }
    }
}
