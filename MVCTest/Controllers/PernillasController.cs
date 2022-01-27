#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MVCTest.Data;
using MVCTest.Models;

namespace MVCTest.Controllers
{
    public class PernillasController : Controller
    {
        private readonly MVCTestContext _context;

        public PernillasController(MVCTestContext context)
        {
            _context = context;
        }

        // GET: Pernillas
        public async Task<IActionResult> Index()
        {
            var viewModel = _context.Pernilla.Select(p => new PernillaViewModel
            {
                FirstName = p.FirstName,
                
            });
            return View(nameof(Index), await _context.Pernilla.ToListAsync());
        }

        // GET: Pernillas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pernilla = await _context.Pernilla
                .FirstOrDefaultAsync(m => m.Id == id);
            if (pernilla == null)
            {
                return NotFound();
            }

            return View(pernilla);
        }

        // GET: Pernillas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Pernillas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,FirstName,LastName")] Pernilla pernilla)
        {
            if (ModelState.IsValid)
            {
                _context.Add(pernilla);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(pernilla);
        }

        // GET: Pernillas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pernilla = await _context.Pernilla.FindAsync(id);
            if (pernilla == null)
            {
                return NotFound();
            }
            return View(pernilla);
        }

        // POST: Pernillas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FirstName,LastName")] Pernilla pernilla)
        {
            if (id != pernilla.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pernilla);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PernillaExists(pernilla.Id))
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
            return View(pernilla);
        }

        // GET: Pernillas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pernilla = await _context.Pernilla
                .FirstOrDefaultAsync(m => m.Id == id);
            if (pernilla == null)
            {
                return NotFound();
            }

            return View(pernilla);
        }

        // POST: Pernillas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var pernilla = await _context.Pernilla.FindAsync(id);
            _context.Pernilla.Remove(pernilla);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PernillaExists(int id)
        {
            return _context.Pernilla.Any(e => e.Id == id);
        }
    }
}
