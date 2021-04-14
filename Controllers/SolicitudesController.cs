using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Ejecuciones.Data;
using Ejecuciones.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Hosting;
using Ejecuciones.Helpers;

namespace Ejecuciones.Controllers
{
    public class SolicitudesController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment webHostEnvironment;

        public SolicitudesController(ApplicationDbContext context, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            this.webHostEnvironment = webHostEnvironment;
        }

        // GET: Solicitudes
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Solicitud.Include(s => s.Despacho).Include(s => s.EstadoSolicitud).Include(s => s.TipoSolicitud);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Solicitudes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var solicitud = await _context.Solicitud
                .Include(s => s.Despacho)
                .Include(s => s.EstadoSolicitud)
                .Include(s => s.TipoSolicitud)
                .FirstOrDefaultAsync(m => m.SolicitudId == id);
            if (solicitud == null)
            {
                return NotFound();
            }

            return View(solicitud);
        }

        // GET: Solicitudes/Create
        public IActionResult Create()
        {
            ViewData["DespachoId"] = new SelectList(_context.Despacho, "DespachoId", "NombreDespacho");
            ViewData["EstadoSolicitudId"] = new SelectList(_context.EstadoSolicitud, "EstadoSolicitudId", "NombreEstadoSolicitud");
            ViewData["TipoSolicitudId"] = new SelectList(_context.TipoSolicitud, "TipoSolicitudId", "NombreSolicitud");
            return View();
        }

        // POST: Solicitudes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        //public async Task<IActionResult> Create([Bind("SolicitudId,DespachoId,TipoSolicitudId,FechaSolicitud,CedulaCondenado,NombresCondenado,ApellidosCondenado,AnexosSolicitud,CuadernosSolicitud,FoliosSolicitud,EstadoSolicitudId")] Solicitud solicitud, IFormFile file)
        public async Task<IActionResult> Create(Solicitud solicitud)
        {
            if (ModelState.IsValid)
            {

                if (solicitud.SolicitudPdf != null)
                {
                    string folder = @"solicitudes\";
                    UploadFiles uploadFiles = new UploadFiles();
                    solicitud.AnexosSolicitud = await uploadFiles.UploadPDF(webHostEnvironment, folder, solicitud.SolicitudPdf);
                }

                solicitud.FechaSolicitud = DateTime.Now;
                //solicitud.EstadoSolicitudId = (_context.EstadoSolicitud, "EstadoSolicitudId", "NombreEstadoSolicitud" = 'REGISTRADA');
                solicitud.EstadoSolicitudId = 2;

                _context.Add(solicitud);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["DespachoId"] = new SelectList(_context.Despacho, "DespachoId", "NombreDespacho", solicitud.DespachoId);
            ViewData["EstadoSolicitudId"] = new SelectList(_context.EstadoSolicitud, "EstadoSolicitudId", "NombreEstadoSolicitud", solicitud.EstadoSolicitudId);
            ViewData["TipoSolicitudId"] = new SelectList(_context.TipoSolicitud, "TipoSolicitudId", "NombreSolicitud", solicitud.TipoSolicitudId);
            return View(solicitud);
        }

        // GET: Solicitudes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var solicitud = await _context.Solicitud.FindAsync(id);
            if (solicitud == null)
            {
                return NotFound();
            }
            ViewData["DespachoId"] = new SelectList(_context.Despacho, "DespachoId", "NombreDespacho", solicitud.DespachoId);
            ViewData["EstadoSolicitudId"] = new SelectList(_context.EstadoSolicitud, "EstadoSolicitudId", "NombreEstadoSolicitud", solicitud.EstadoSolicitudId);
            ViewData["TipoSolicitudId"] = new SelectList(_context.TipoSolicitud, "TipoSolicitudId", "NombreSolicitud", solicitud.TipoSolicitudId);
            return View(solicitud);
        }

        // POST: Solicitudes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("SolicitudId,DespachoId,TipoSolicitudId,FechaSolicitud,CedulaCondenado,NombresCondenado,ApellidosCondenado,AnexosSolicitud,CuadernosSolicitud,FoliosSolicitud,EstadoSolicitudId")] Solicitud solicitud)
        {
            if (id != solicitud.SolicitudId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    solicitud.FechaSolicitud = DateTime.Now;
                    //solicitud.EstadoSolicitudId = (_context.EstadoSolicitud, "EstadoSolicitudId", "NombreEstadoSolicitud" = 'REGISTRADA');
                    solicitud.EstadoSolicitudId = 2;

                    _context.Update(solicitud);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SolicitudExists(solicitud.SolicitudId))
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
            ViewData["DespachoId"] = new SelectList(_context.Despacho, "DespachoId", "NombreDespacho", solicitud.DespachoId);
            ViewData["EstadoSolicitudId"] = new SelectList(_context.EstadoSolicitud, "EstadoSolicitudId", "NombreEstadoSolicitud", solicitud.EstadoSolicitudId);
            ViewData["TipoSolicitudId"] = new SelectList(_context.TipoSolicitud, "TipoSolicitudId", "NombreSolicitud", solicitud.TipoSolicitudId);
            return View(solicitud);
        }

        // GET: Solicitudes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var solicitud = await _context.Solicitud
                .Include(s => s.Despacho)
                .Include(s => s.EstadoSolicitud)
                .Include(s => s.TipoSolicitud)
                .FirstOrDefaultAsync(m => m.SolicitudId == id);
            if (solicitud == null)
            {
                return NotFound();
            }

            return View(solicitud);
        }

        // POST: Solicitudes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var solicitud = await _context.Solicitud.FindAsync(id);
            _context.Solicitud.Remove(solicitud);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SolicitudExists(int id)
        {
            return _context.Solicitud.Any(e => e.SolicitudId == id);
        }
    }
}
