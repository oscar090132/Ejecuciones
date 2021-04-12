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
    public class TipoSolicitudesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TipoSolicitudesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: TipoSolicitudes
        public async Task<IActionResult> Index()
        {
            return View(await _context.TipoSolicitud.ToListAsync());
        }

        // GET: TipoSolicitudes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoSolicitud = await _context.TipoSolicitud
                .FirstOrDefaultAsync(m => m.TipoSolicitudId == id);
            if (tipoSolicitud == null)
            {
                return NotFound();
            }

            return View(tipoSolicitud);
        }

        // GET: TipoSolicitudes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TipoSolicitudes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TipoSolicitudId,NombreSolicitud")] TipoSolicitud tipoSolicitud)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tipoSolicitud);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tipoSolicitud);
        }

        // GET: TipoSolicitudes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoSolicitud = await _context.TipoSolicitud.FindAsync(id);
            if (tipoSolicitud == null)
            {
                return NotFound();
            }
            return View(tipoSolicitud);
        }

        // POST: TipoSolicitudes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TipoSolicitudId,NombreSolicitud")] TipoSolicitud tipoSolicitud)
        {
            if (id != tipoSolicitud.TipoSolicitudId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tipoSolicitud);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TipoSolicitudExists(tipoSolicitud.TipoSolicitudId))
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
            return View(tipoSolicitud);
        }

        // GET: TipoSolicitudes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoSolicitud = await _context.TipoSolicitud
                .FirstOrDefaultAsync(m => m.TipoSolicitudId == id);
            if (tipoSolicitud == null)
            {
                return NotFound();
            }

            return View(tipoSolicitud);
        }

        // POST: TipoSolicitudes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tipoSolicitud = await _context.TipoSolicitud.FindAsync(id);
            _context.TipoSolicitud.Remove(tipoSolicitud);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TipoSolicitudExists(int id)
        {
            return _context.TipoSolicitud.Any(e => e.TipoSolicitudId == id);
        }
    }
}
