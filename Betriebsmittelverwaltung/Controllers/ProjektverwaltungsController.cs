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
    public class ProjektverwaltungsController : Controller
    {
        private readonly VerwaltungContext _context;

        public ProjektverwaltungsController(VerwaltungContext context)
        {
            _context = context;
        }

        // GET: Projektverwaltungs
        public async Task<IActionResult> Index()
        {
            return View(await _context.Projektverwaltungs.ToListAsync());
        }

        // GET: Projektverwaltungs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var projektverwaltung = await _context.Projektverwaltungs
                .FirstOrDefaultAsync(m => m.ID == id);
            if (projektverwaltung == null)
            {
                return NotFound();
            }

            return View(projektverwaltung);
        }

        // GET: Projektverwaltungs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Projektverwaltungs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Typ,Ausleihdatum,Rückgabe")] Projektverwaltung projektverwaltung)
        {
            if (ModelState.IsValid)
            {
                _context.Add(projektverwaltung);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(projektverwaltung);
        }

        // GET: Projektverwaltungs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var projektverwaltung = await _context.Projektverwaltungs.FindAsync(id);
            if (projektverwaltung == null)
            {
                return NotFound();
            }
            return View(projektverwaltung);
        }

        // POST: Projektverwaltungs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Typ,Ausleihdatum,Rückgabe")] Projektverwaltung projektverwaltung)
        {
            if (id != projektverwaltung.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(projektverwaltung);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProjektverwaltungExists(projektverwaltung.ID))
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
            return View(projektverwaltung);
        }

        // GET: Projektverwaltungs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var projektverwaltung = await _context.Projektverwaltungs
                .FirstOrDefaultAsync(m => m.ID == id);
            if (projektverwaltung == null)
            {
                return NotFound();
            }

            return View(projektverwaltung);
        }

        // POST: Projektverwaltungs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var projektverwaltung = await _context.Projektverwaltungs.FindAsync(id);
            _context.Projektverwaltungs.Remove(projektverwaltung);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProjektverwaltungExists(int id)
        {
            return _context.Projektverwaltungs.Any(e => e.ID == id);
        }
    }
}
