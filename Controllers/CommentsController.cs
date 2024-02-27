#nullable disable
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

namespace aspcore.Controllers
{
    [Authorize]

    public class CommentsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CommentsController(ApplicationDbContext context)
        {
            _context = context;
        }


        // GET: Comments/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Comments/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Body")] Comment comment, int? id)
        {
            if (!string.IsNullOrWhiteSpace(comment.Body))
            {
                comment.TicketId = id.Value;
                comment.date = DateTime.Now;
                comment.UserId = User.Identity.Name;// _context.Users.FirstOrDefault( item => item.Name == User.Identity.Name).;
                _context.Add(comment);
                await _context.SaveChangesAsync();
                return Redirect("/Tickets/Details/" + id.Value);
            }
            return View(comment);
        }
    }
}
