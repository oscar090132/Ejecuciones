using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Ejecuciones.Data;
using Ejecuciones.Models;

namespace Ejecuciones.Controllers
{
    public class DespachoesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DespachoesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Despachoes
        public async Task<IActionResult> Index()
        {
            return View(await _context.Despacho.ToListAsync());
        }

        // GET: Despachoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var despacho = await _context.Despacho
                .FirstOrDefaultAsync(m => m.DespachoId == id);
            if (despacho == null)
            {
                return NotFound();
            }

            return View(despacho);
        }

        // GET: Despachoes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Despachoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DespachoId,NombreDespacho")] Despacho despacho)
        {
            if (ModelState.IsValid)
            {
                _context.Add(despacho);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(despacho);
        }

        // GET: Despachoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var despacho = await _context.Despacho.FindAsync(id);
            if (despacho == null)
            {
                return NotFound();
            }
            return View(despacho);
        }

        // POST: Despachoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("DespachoId,NombreDespacho")] Despacho despacho)
        {
            if (id != despacho.DespachoId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(despacho);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DespachoExists(despacho.DespachoId))
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
            return View(despacho);
        }

        // GET: Despachoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var despacho = await _context.Despacho
                .FirstOrDefaultAsync(m => m.DespachoId == id);
            if (despacho == null)
            {
                return NotFound();
            }

            return View(despacho);
        }

        // POST: Despachoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var despacho = await _context.Despacho.FindAsync(id);
            _context.Despacho.Remove(despacho);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DespachoExists(int id)
        {
            return _context.Despacho.Any(e => e.DespachoId == id);
        }
    }
}
