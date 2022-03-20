using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MyUni.Web.Data;
using MyUni.Web.Models;

namespace MyUni.Web.Controllers
{
    public class ThesesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ThesesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Theses
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Thesis.Include(t => t.Subject);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Theses/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var thesis = await _context.Thesis
                .Include(t => t.Subject)
                .FirstOrDefaultAsync(m => m.ThesisId == id);
            if (thesis == null)
            {
                return NotFound();
            }

            return View(thesis);
        }

        // GET: Theses/Create
        public IActionResult Create()
        {
            ViewData["SubjectId"] = new SelectList(_context.Subjects, "SubjectId", "SubjectName");
            return View();
        }

        // POST: Theses/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ThesisId,ThesisTitle,ThesisDesc,SubjectId,EnrollmentID,FacultyID,AssignDate")] Thesis thesis)
        {
            if (ModelState.IsValid)
            {
                _context.Add(thesis);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["SubjectId"] = new SelectList(_context.Subjects, "SubjectId", "SubjectName", thesis.SubjectId);
            return View(thesis);
        }

        // GET: Theses/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var thesis = await _context.Thesis.FindAsync(id);
            if (thesis == null)
            {
                return NotFound();
            }
            ViewData["SubjectId"] = new SelectList(_context.Subjects, "SubjectId", "SubjectName", thesis.SubjectId);
            return View(thesis);
        }

        // POST: Theses/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ThesisId,ThesisTitle,ThesisDesc,SubjectId,EnrollmentID,FacultyID,AssignDate")] Thesis thesis)
        {
            if (id != thesis.ThesisId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(thesis);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ThesisExists(thesis.ThesisId))
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
            ViewData["SubjectId"] = new SelectList(_context.Subjects, "SubjectId", "SubjectName", thesis.SubjectId);
            return View(thesis);
        }

        // GET: Theses/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var thesis = await _context.Thesis
                .Include(t => t.Subject)
                .FirstOrDefaultAsync(m => m.ThesisId == id);
            if (thesis == null)
            {
                return NotFound();
            }

            return View(thesis);
        }

        // POST: Theses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var thesis = await _context.Thesis.FindAsync(id);
            _context.Thesis.Remove(thesis);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ThesisExists(int id)
        {
            return _context.Thesis.Any(e => e.ThesisId == id);
        }
    }
}
