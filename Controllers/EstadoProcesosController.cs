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
    public class EstadoProcesosController : Controller
    {
        private readonly ApplicationDbContext _context;

        public EstadoProcesosController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: EstadoProcesos
        public async Task<IActionResult> Index()
        {
            return View(await _context.EstadoProceso.ToListAsync());
        }

        // GET: EstadoProcesos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var estadoProceso = await _context.EstadoProceso
                .FirstOrDefaultAsync(m => m.EstadoProcesoId == id);
            if (estadoProceso == null)
            {
                return NotFound();
            }

            return View(estadoProceso);
        }

        // GET: EstadoProcesos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: EstadoProcesos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("EstadoProcesoId,NombreEstadoProceso")] EstadoProceso estadoProceso)
        {
            if (ModelState.IsValid)
            {
                _context.Add(estadoProceso);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(estadoProceso);
        }

        // GET: EstadoProcesos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var estadoProceso = await _context.EstadoProceso.FindAsync(id);
            if (estadoProceso == null)
            {
                return NotFound();
            }
            return View(estadoProceso);
        }

        // POST: EstadoProcesos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("EstadoProcesoId,NombreEstadoProceso")] EstadoProceso estadoProceso)
        {
            if (id != estadoProceso.EstadoProcesoId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(estadoProceso);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EstadoProcesoExists(estadoProceso.EstadoProcesoId))
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
            return View(estadoProceso);
        }

        // GET: EstadoProcesos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var estadoProceso = await _context.EstadoProceso
                .FirstOrDefaultAsync(m => m.EstadoProcesoId == id);
            if (estadoProceso == null)
            {
                return NotFound();
            }

            return View(estadoProceso);
        }

        // POST: EstadoProcesos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var estadoProceso = await _context.EstadoProceso.FindAsync(id);
            _context.EstadoProceso.Remove(estadoProceso);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EstadoProcesoExists(int id)
        {
            return _context.EstadoProceso.Any(e => e.EstadoProcesoId == id);
        }
    }
}
