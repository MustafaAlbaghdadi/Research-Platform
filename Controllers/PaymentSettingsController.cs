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

    public class PaymentSettingsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PaymentSettingsController(ApplicationDbContext context)
        {
            _context = context;
        }
        [AllowAnonymous]
        public async Task<PaymentSetting> Fetch()
        {
            return await _context.paymentSettings.FirstAsync();
        }



        // GET: PaymentSettings/Edit/5
        public async Task<IActionResult> Index()
        {

            if (  _context.paymentSettings.Count() == 0)
            {
                _context.paymentSettings.Add(new PaymentSetting());
                _context.SaveChanges();
            }

            var paymentSetting = await _context.paymentSettings.FirstAsync();
            if (paymentSetting == null)
            {
                return NotFound();
            }
            return View(paymentSetting);
        }

        // POST: PaymentSettings/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index(int id,  PaymentSetting paymentSetting)
        {
            if (id != paymentSetting.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(paymentSetting);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PaymentSettingExists(paymentSetting.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return Redirect("/");
            }
            return View(paymentSetting);
        }

 

        private bool PaymentSettingExists(int id)
        {
          return (_context.paymentSettings?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
