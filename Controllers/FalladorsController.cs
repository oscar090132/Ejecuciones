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
    public class FalladorsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public FalladorsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Falladors
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Fallador.Include(f => f.Departamento).Include(f => f.Municipio);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Falladors/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fallador = await _context.Fallador
                .Include(f => f.Departamento)
                .Include(f => f.Municipio)
                .FirstOrDefaultAsync(m => m.FalladorId == id);
            if (fallador == null)
            {
                return NotFound();
            }

            return View(fallador);
        }

        // GET: Falladors/Create
        public IActionResult Create()
        {
            ViewData["DepartamentoId"] = new SelectList(_context.Departamentos, "DepartamentoId", "CodigoDepartamento");
            ViewData["MunicipioId"] = new SelectList(_context.Municipios, "MunicipioId", "CodigoMunicipio");
            return View();
        }

        // POST: Falladors/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("FalladorId,DepartamentoId,MunicipioId,JuzgadoFallador")] Fallador fallador)
        {
            if (ModelState.IsValid)
            {
                _context.Add(fallador);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["DepartamentoId"] = new SelectList(_context.Departamentos, "DepartamentoId", "CodigoDepartamento", fallador.DepartamentoId);
            ViewData["MunicipioId"] = new SelectList(_context.Municipios, "MunicipioId", "CodigoMunicipio", fallador.MunicipioId);
            return View(fallador);
        }

        // GET: Falladors/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fallador = await _context.Fallador.FindAsync(id);
            if (fallador == null)
            {
                return NotFound();
            }
            ViewData["DepartamentoId"] = new SelectList(_context.Departamentos, "DepartamentoId", "CodigoDepartamento", fallador.DepartamentoId);
            ViewData["MunicipioId"] = new SelectList(_context.Municipios, "MunicipioId", "CodigoMunicipio", fallador.MunicipioId);
            return View(fallador);
        }

        // POST: Falladors/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("FalladorId,DepartamentoId,MunicipioId,JuzgadoFallador")] Fallador fallador)
        {
            if (id != fallador.FalladorId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(fallador);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FalladorExists(fallador.FalladorId))
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
            ViewData["DepartamentoId"] = new SelectList(_context.Departamentos, "DepartamentoId", "CodigoDepartamento", fallador.DepartamentoId);
            ViewData["MunicipioId"] = new SelectList(_context.Municipios, "MunicipioId", "CodigoMunicipio", fallador.MunicipioId);
            return View(fallador);
        }

        // GET: Falladors/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fallador = await _context.Fallador
                .Include(f => f.Departamento)
                .Include(f => f.Municipio)
                .FirstOrDefaultAsync(m => m.FalladorId == id);
            if (fallador == null)
            {
                return NotFound();
            }

            return View(fallador);
        }

        // POST: Falladors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var fallador = await _context.Fallador.FindAsync(id);
            _context.Fallador.Remove(fallador);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FalladorExists(int id)
        {
            return _context.Fallador.Any(e => e.FalladorId == id);
        }
    }
}
