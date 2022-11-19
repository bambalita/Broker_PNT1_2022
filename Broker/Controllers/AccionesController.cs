using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Broker.Models;

namespace Broker.Controllers
{
    public class AccionesController : Controller
    {
        private readonly Broker_Context _context;

        public AccionesController(Broker_Context context)
        {
            _context = context;
        }

        // GET: Acciones
        public async Task<IActionResult> Index()
        {
              return View(await _context.Acciones.ToListAsync());
        }

        // GET: Acciones/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Acciones == null)
            {
                return NotFound();
            }

            var accion = await _context.Acciones
                .FirstOrDefaultAsync(m => m.Id == id);
            if (accion == null)
            {
                return NotFound();
            }

            return View(accion);
        }

        // GET: Acciones/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Acciones/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Empresa,Precio")] Accion accion)
        {
            if (ModelState.IsValid)
            {
                _context.Add(accion);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(accion);
        }

        // GET: Acciones/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Acciones == null)
            {
                return NotFound();
            }

            var accion = await _context.Acciones.FindAsync(id);
            if (accion == null)
            {
                return NotFound();
            }
            return View(accion);
        }

        // POST: Acciones/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Empresa,Precio")] Accion accion)
        {
            if (id != accion.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(accion);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AccionExists(accion.Id))
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
            return View(accion);
        }

        // GET: Acciones/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Acciones == null)
            {
                return NotFound();
            }

            var accion = await _context.Acciones
                .FirstOrDefaultAsync(m => m.Id == id);
            if (accion == null)
            {
                return NotFound();
            }

            return View(accion);
        }

        // POST: Acciones/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Acciones == null)
            {
                return Problem("Entity set 'Broker_Context.Acciones'  is null.");
            }
            var accion = await _context.Acciones.FindAsync(id);
            if (accion != null)
            {
                _context.Acciones.Remove(accion);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AccionExists(int id)
        {
          return _context.Acciones.Any(e => e.Id == id);
        }
    }
}
