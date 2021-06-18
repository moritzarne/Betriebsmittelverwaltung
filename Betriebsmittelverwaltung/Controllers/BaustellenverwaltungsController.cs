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
    public class BaustellenverwaltungsController : Controller
    {
        private readonly VerwaltungContext _context;

        public BaustellenverwaltungsController(VerwaltungContext context)
        {
            _context = context;
        }

        // GET: Baustellenverwaltungs
        public async Task<IActionResult> Index()
        {
            return View(await _context.Baustellenverwaltungs.ToListAsync());
        }

        // GET: Baustellenverwaltungs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var baustellenverwaltung = await _context.Baustellenverwaltungs
                .FirstOrDefaultAsync(m => m.ID == id);
            if (baustellenverwaltung == null)
            {
                return NotFound();
            }

            return View(baustellenverwaltung);
        }

        // GET: Baustellenverwaltungs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Baustellenverwaltungs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Name,Beschreibung")] Baustellenverwaltung baustellenverwaltung)
        {
            if (ModelState.IsValid)
            {
                _context.Add(baustellenverwaltung);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(baustellenverwaltung);
        }

        // GET: Baustellenverwaltungs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var baustellenverwaltung = await _context.Baustellenverwaltungs.FindAsync(id);
            if (baustellenverwaltung == null)
            {
                return NotFound();
            }
            return View(baustellenverwaltung);
        }

        // POST: Baustellenverwaltungs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Name,Beschreibung")] Baustellenverwaltung baustellenverwaltung)
        {
            if (id != baustellenverwaltung.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(baustellenverwaltung);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BaustellenverwaltungExists(baustellenverwaltung.ID))
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
            return View(baustellenverwaltung);
        }

        // GET: Baustellenverwaltungs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var baustellenverwaltung = await _context.Baustellenverwaltungs
                .FirstOrDefaultAsync(m => m.ID == id);
            if (baustellenverwaltung == null)
            {
                return NotFound();
            }

            return View(baustellenverwaltung);
        }

        // POST: Baustellenverwaltungs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var baustellenverwaltung = await _context.Baustellenverwaltungs.FindAsync(id);
            _context.Baustellenverwaltungs.Remove(baustellenverwaltung);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BaustellenverwaltungExists(int id)
        {
            return _context.Baustellenverwaltungs.Any(e => e.ID == id);
        }
    }
}
