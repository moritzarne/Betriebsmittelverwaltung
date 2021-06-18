using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Betriebsmittelverwaltung.Data;
using Betriebsmittelverwaltung.Models;

namespace Betriebsmittelverwaltung
{
    public class NutzerverwaltungsController : Controller
    {
        private readonly VerwaltungContext _context;

        public NutzerverwaltungsController(VerwaltungContext context)
        {
            _context = context;
        }

        // GET: Nutzerverwaltungs
        public async Task<IActionResult> Index()
        {
            return View(await _context.Nutzerverwaltungs.ToListAsync());
        }

        // GET: Nutzerverwaltungs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nutzerverwaltung = await _context.Nutzerverwaltungs
                .FirstOrDefaultAsync(m => m.ID == id);
            if (nutzerverwaltung == null)
            {
                return NotFound();
            }

            return View(nutzerverwaltung);
        }

        // GET: Nutzerverwaltungs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Nutzerverwaltungs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Rolle,Vorname,Nachname")] Nutzerverwaltung nutzerverwaltung)
        {
            if (ModelState.IsValid)
            {
                _context.Add(nutzerverwaltung);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(nutzerverwaltung);
        }

        // GET: Nutzerverwaltungs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nutzerverwaltung = await _context.Nutzerverwaltungs.FindAsync(id);
            if (nutzerverwaltung == null)
            {
                return NotFound();
            }
            return View(nutzerverwaltung);
        }

        // POST: Nutzerverwaltungs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Rolle,Vorname,Nachname")] Nutzerverwaltung nutzerverwaltung)
        {
            if (id != nutzerverwaltung.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(nutzerverwaltung);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NutzerverwaltungExists(nutzerverwaltung.ID))
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
            return View(nutzerverwaltung);
        }

        // GET: Nutzerverwaltungs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nutzerverwaltung = await _context.Nutzerverwaltungs
                .FirstOrDefaultAsync(m => m.ID == id);
            if (nutzerverwaltung == null)
            {
                return NotFound();
            }

            return View(nutzerverwaltung);
        }

        // POST: Nutzerverwaltungs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var nutzerverwaltung = await _context.Nutzerverwaltungs.FindAsync(id);
            _context.Nutzerverwaltungs.Remove(nutzerverwaltung);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool NutzerverwaltungExists(int id)
        {
            return _context.Nutzerverwaltungs.Any(e => e.ID == id);
        }
    }
}
