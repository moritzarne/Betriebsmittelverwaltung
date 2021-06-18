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
    public class RetourenverwaltungsController : Controller
    {
        private readonly VerwaltungContext _context;

        public RetourenverwaltungsController(VerwaltungContext context)
        {
            _context = context;
        }

        // GET: Retourenverwaltungs
        public async Task<IActionResult> Index()
        {
            return View(await _context.Retourenverwaltungs.ToListAsync());
        }

        // GET: Retourenverwaltungs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var retourenverwaltung = await _context.Retourenverwaltungs
                .FirstOrDefaultAsync(m => m.ID == id);
            if (retourenverwaltung == null)
            {
                return NotFound();
            }

            return View(retourenverwaltung);
        }

        // GET: Retourenverwaltungs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Retourenverwaltungs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Typ,Kaufdatum,Wartungsintverall,Verfügbar")] Retourenverwaltung retourenverwaltung)
        {
            if (ModelState.IsValid)
            {
                _context.Add(retourenverwaltung);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(retourenverwaltung);
        }

        // GET: Retourenverwaltungs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var retourenverwaltung = await _context.Retourenverwaltungs.FindAsync(id);
            if (retourenverwaltung == null)
            {
                return NotFound();
            }
            return View(retourenverwaltung);
        }

        // POST: Retourenverwaltungs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Typ,Kaufdatum,Wartungsintverall,Verfügbar")] Retourenverwaltung retourenverwaltung)
        {
            if (id != retourenverwaltung.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(retourenverwaltung);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RetourenverwaltungExists(retourenverwaltung.ID))
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
            return View(retourenverwaltung);
        }

        // GET: Retourenverwaltungs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var retourenverwaltung = await _context.Retourenverwaltungs
                .FirstOrDefaultAsync(m => m.ID == id);
            if (retourenverwaltung == null)
            {
                return NotFound();
            }

            return View(retourenverwaltung);
        }

        // POST: Retourenverwaltungs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var retourenverwaltung = await _context.Retourenverwaltungs.FindAsync(id);
            _context.Retourenverwaltungs.Remove(retourenverwaltung);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RetourenverwaltungExists(int id)
        {
            return _context.Retourenverwaltungs.Any(e => e.ID == id);
        }
    }
}
