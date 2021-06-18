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
    public class BestandsverwaltungsController : Controller
    {
        private readonly VerwaltungContext _context;

        public BestandsverwaltungsController(VerwaltungContext context)
        {
            _context = context;
        }

        // GET: Bestandsverwaltungs
        public async Task<IActionResult> Index()
        {
            return View(await _context.Bestandsverwaltungs.ToListAsync());
        }

        // GET: Bestandsverwaltungs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bestandsverwaltung = await _context.Bestandsverwaltungs
                .FirstOrDefaultAsync(m => m.ID == id);
            if (bestandsverwaltung == null)
            {
                return NotFound();
            }

            return View(bestandsverwaltung);
        }

        // GET: Bestandsverwaltungs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Bestandsverwaltungs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Typ,Kaufdatum,Wartungsintervall,Verfübar")] Bestandsverwaltung bestandsverwaltung)
        {
            if (ModelState.IsValid)
            {
                _context.Add(bestandsverwaltung);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(bestandsverwaltung);
        }

        // GET: Bestandsverwaltungs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bestandsverwaltung = await _context.Bestandsverwaltungs.FindAsync(id);
            if (bestandsverwaltung == null)
            {
                return NotFound();
            }
            return View(bestandsverwaltung);
        }

        // POST: Bestandsverwaltungs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Typ,Kaufdatum,Wartungsintervall,Verfübar")] Bestandsverwaltung bestandsverwaltung)
        {
            if (id != bestandsverwaltung.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(bestandsverwaltung);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BestandsverwaltungExists(bestandsverwaltung.ID))
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
            return View(bestandsverwaltung);
        }

        // GET: Bestandsverwaltungs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bestandsverwaltung = await _context.Bestandsverwaltungs
                .FirstOrDefaultAsync(m => m.ID == id);
            if (bestandsverwaltung == null)
            {
                return NotFound();
            }

            return View(bestandsverwaltung);
        }

        // POST: Bestandsverwaltungs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var bestandsverwaltung = await _context.Bestandsverwaltungs.FindAsync(id);
            _context.Bestandsverwaltungs.Remove(bestandsverwaltung);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BestandsverwaltungExists(int id)
        {
            return _context.Bestandsverwaltungs.Any(e => e.ID == id);
        }
    }
}
