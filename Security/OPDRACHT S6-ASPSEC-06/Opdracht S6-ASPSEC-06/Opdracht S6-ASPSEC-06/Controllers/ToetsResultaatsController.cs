using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Opdracht_S6_ASPSEC_06.Data;
using Opdracht_S6_ASPSEC_06.Models;

namespace Opdracht_S6_ASPSEC_06.Controllers
{
    public class ToetsResultaatsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ToetsResultaatsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: ToetsResultaats
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.ToetsResultaten.Include(t => t.Student).Include(t => t.Vak);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: ToetsResultaats/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var toetsResultaat = await _context.ToetsResultaten
                .Include(t => t.Student)
                .Include(t => t.Vak)
                .FirstOrDefaultAsync(m => m.ResultaatId == id);
            if (toetsResultaat == null)
            {
                return NotFound();
            }

            return View(toetsResultaat);
        }

        // GET: ToetsResultaats/Create
        public IActionResult Create()
        {
            ViewData["StudentId"] = new SelectList(_context.Studenten, "StudentId", "StudentId");
            ViewData["VakId"] = new SelectList(_context.Vakken, "VakId", "VakId");
            return View();
        }

        // POST: ToetsResultaats/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ResultaatId,StudentId,VakId,Cijfer,Datum")] ToetsResultaat toetsResultaat)
        {
            if (ModelState.IsValid)
            {
                _context.Add(toetsResultaat);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["StudentId"] = new SelectList(_context.Studenten, "StudentId", "StudentId", toetsResultaat.StudentId);
            ViewData["VakId"] = new SelectList(_context.Vakken, "VakId", "VakId", toetsResultaat.VakId);
            return View(toetsResultaat);
        }

        // GET: ToetsResultaats/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var toetsResultaat = await _context.ToetsResultaten.FindAsync(id);
            if (toetsResultaat == null)
            {
                return NotFound();
            }
            ViewData["StudentId"] = new SelectList(_context.Studenten, "StudentId", "StudentId", toetsResultaat.StudentId);
            ViewData["VakId"] = new SelectList(_context.Vakken, "VakId", "VakId", toetsResultaat.VakId);
            return View(toetsResultaat);
        }

        // POST: ToetsResultaats/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ResultaatId,StudentId,VakId,Cijfer,Datum")] ToetsResultaat toetsResultaat)
        {
            if (id != toetsResultaat.ResultaatId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(toetsResultaat);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ToetsResultaatExists(toetsResultaat.ResultaatId))
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
            ViewData["StudentId"] = new SelectList(_context.Studenten, "StudentId", "StudentId", toetsResultaat.StudentId);
            ViewData["VakId"] = new SelectList(_context.Vakken, "VakId", "VakId", toetsResultaat.VakId);
            return View(toetsResultaat);
        }

        // GET: ToetsResultaats/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var toetsResultaat = await _context.ToetsResultaten
                .Include(t => t.Student)
                .Include(t => t.Vak)
                .FirstOrDefaultAsync(m => m.ResultaatId == id);
            if (toetsResultaat == null)
            {
                return NotFound();
            }

            return View(toetsResultaat);
        }

        // POST: ToetsResultaats/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var toetsResultaat = await _context.ToetsResultaten.FindAsync(id);
            if (toetsResultaat != null)
            {
                _context.ToetsResultaten.Remove(toetsResultaat);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ToetsResultaatExists(int id)
        {
            return _context.ToetsResultaten.Any(e => e.ResultaatId == id);
        }
    }
}
