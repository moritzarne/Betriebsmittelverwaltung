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
    public class AuftragsverwaltungsController : Controller
    {
        private readonly VerwaltungContext _context;

        public AuftragsverwaltungsController(VerwaltungContext context)
        {
            _context = context;
        }

        // GET: Auftragsverwaltungs
        public async Task<IActionResult> Index()
        {
            return View(await _context.Auftragsverwaltungs.ToListAsync());
        }

        // GET: Auftragsverwaltungs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var auftragsverwaltung = await _context.Auftragsverwaltungs
                .FirstOrDefaultAsync(m => m.ID == id);
            if (auftragsverwaltung == null)
            {
                return NotFound();
            }

            return View(auftragsverwaltung);
        }

        // GET: Auftragsverwaltungs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Auftragsverwaltungs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Typ,Verfügbar")] Auftragsverwaltung auftragsverwaltung)
        {
            if (ModelState.IsValid)
            {
                _context.Add(auftragsverwaltung);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(auftragsverwaltung);
        }

        // GET: Auftragsverwaltungs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var auftragsverwaltung = await _context.Auftragsverwaltungs.FindAsync(id);
            if (auftragsverwaltung == null)
            {
                return NotFound();
            }
            return View(auftragsverwaltung);
        }

        // POST: Auftragsverwaltungs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Typ,Verfügbar")] Auftragsverwaltung auftragsverwaltung)
        {
            if (id != auftragsverwaltung.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(auftragsverwaltung);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AuftragsverwaltungExists(auftragsverwaltung.ID))
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
            return View(auftragsverwaltung);
        }

        // GET: Auftragsverwaltungs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var auftragsverwaltung = await _context.Auftragsverwaltungs
                .FirstOrDefaultAsync(m => m.ID == id);
            if (auftragsverwaltung == null)
            {
                return NotFound();
            }

            return View(auftragsverwaltung);
        }

        // POST: Auftragsverwaltungs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var auftragsverwaltung = await _context.Auftragsverwaltungs.FindAsync(id);
            _context.Auftragsverwaltungs.Remove(auftragsverwaltung);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AuftragsverwaltungExists(int id)
        {
            return _context.Auftragsverwaltungs.Any(e => e.ID == id);
        }
    }
}
