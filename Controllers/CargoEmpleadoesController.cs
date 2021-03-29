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
    public class CargoEmpleadoesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CargoEmpleadoesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: CargoEmpleadoes
        public async Task<IActionResult> Index()
        {
            return View(await _context.CargoEmpleado.ToListAsync());
        }

        // GET: CargoEmpleadoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cargoEmpleado = await _context.CargoEmpleado
                .FirstOrDefaultAsync(m => m.CargoId == id);
            if (cargoEmpleado == null)
            {
                return NotFound();
            }

            return View(cargoEmpleado);
        }

        // GET: CargoEmpleadoes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CargoEmpleadoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CargoId,NombreCargo")] CargoEmpleado cargoEmpleado)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cargoEmpleado);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(cargoEmpleado);
        }

        // GET: CargoEmpleadoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cargoEmpleado = await _context.CargoEmpleado.FindAsync(id);
            if (cargoEmpleado == null)
            {
                return NotFound();
            }
            return View(cargoEmpleado);
        }

        // POST: CargoEmpleadoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CargoId,NombreCargo")] CargoEmpleado cargoEmpleado)
        {
            if (id != cargoEmpleado.CargoId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cargoEmpleado);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CargoEmpleadoExists(cargoEmpleado.CargoId))
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
            return View(cargoEmpleado);
        }

        // GET: CargoEmpleadoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cargoEmpleado = await _context.CargoEmpleado
                .FirstOrDefaultAsync(m => m.CargoId == id);
            if (cargoEmpleado == null)
            {
                return NotFound();
            }

            return View(cargoEmpleado);
        }

        // POST: CargoEmpleadoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var cargoEmpleado = await _context.CargoEmpleado.FindAsync(id);
            _context.CargoEmpleado.Remove(cargoEmpleado);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CargoEmpleadoExists(int id)
        {
            return _context.CargoEmpleado.Any(e => e.CargoId == id);
        }
    }
}
