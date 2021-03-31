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
    public class ProcesosController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ProcesosController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Procesos
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Proceso.Include(p => p.Despacho).Include(p => p.EstadoProceso).Include(p => p.Fallador);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Procesos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var proceso = await _context.Proceso
                .Include(p => p.Despacho)
                .Include(p => p.EstadoProceso)
                .Include(p => p.Fallador)
                .FirstOrDefaultAsync(m => m.ProcesoId == id);
            if (proceso == null)
            {
                return NotFound();
            }

            return View(proceso);
        }

        // GET: Procesos/Create
        public IActionResult Create()
        {
            ViewData["DespachoId"] = new SelectList(_context.Despacho, "DespachoId", "NombreDespacho");
            ViewData["EstadoProcesoId"] = new SelectList(_context.EstadoProceso, "EstadoProcesoId", "NombreEstadoProceso");
            ViewData["FalladorId"] = new SelectList(_context.Fallador, "FalladorId", "JuzgadoFallador");
            return View();
        }

        // POST: Procesos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ProcesoId,DespachoId,FechaProceso,RadicadoProceso,FalladorId,AnexosSolicitud,CuadernosProceso,FoliosProceso,EstadoProcesoId")] Proceso proceso)
        {
            if (ModelState.IsValid)
            {
                _context.Add(proceso);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["DespachoId"] = new SelectList(_context.Despacho, "DespachoId", "NombreDespacho", proceso.DespachoId);
            ViewData["EstadoProcesoId"] = new SelectList(_context.EstadoProceso, "EstadoProcesoId", "NombreEstadoProceso", proceso.EstadoProcesoId);
            ViewData["FalladorId"] = new SelectList(_context.Fallador, "FalladorId", "JuzgadoFallador", proceso.FalladorId);
            return View(proceso);
        }

        // GET: Procesos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var proceso = await _context.Proceso.FindAsync(id);
            if (proceso == null)
            {
                return NotFound();
            }
            ViewData["DespachoId"] = new SelectList(_context.Despacho, "DespachoId", "NombreDespacho", proceso.DespachoId);
            ViewData["EstadoProcesoId"] = new SelectList(_context.EstadoProceso, "EstadoProcesoId", "NombreEstadoProceso", proceso.EstadoProcesoId);
            ViewData["FalladorId"] = new SelectList(_context.Fallador, "FalladorId", "JuzgadoFallador", proceso.FalladorId);
            return View(proceso);
        }

        // POST: Procesos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ProcesoId,DespachoId,FechaProceso,RadicadoProceso,FalladorId,AnexosSolicitud,CuadernosProceso,FoliosProceso,EstadoProcesoId")] Proceso proceso)
        {
            if (id != proceso.ProcesoId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(proceso);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProcesoExists(proceso.ProcesoId))
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
            ViewData["DespachoId"] = new SelectList(_context.Despacho, "DespachoId", "NombreDespacho", proceso.DespachoId);
            ViewData["EstadoProcesoId"] = new SelectList(_context.EstadoProceso, "EstadoProcesoId", "NombreEstadoProceso", proceso.EstadoProcesoId);
            ViewData["FalladorId"] = new SelectList(_context.Fallador, "FalladorId", "JuzgadoFallador", proceso.FalladorId);
            return View(proceso);
        }

        // GET: Procesos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var proceso = await _context.Proceso
                .Include(p => p.Despacho)
                .Include(p => p.EstadoProceso)
                .Include(p => p.Fallador)
                .FirstOrDefaultAsync(m => m.ProcesoId == id);
            if (proceso == null)
            {
                return NotFound();
            }

            return View(proceso);
        }

        // POST: Procesos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var proceso = await _context.Proceso.FindAsync(id);
            _context.Proceso.Remove(proceso);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProcesoExists(int id)
        {
            return _context.Proceso.Any(e => e.ProcesoId == id);
        }
    }
}
