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
    public class OrdenesController : Controller
    {
        private readonly Broker_Context _context;

        public OrdenesController(Broker_Context context)
        {
            _context = context;
        }

        // GET: Ordenes
        public async Task<IActionResult> Index()
        {
              return View(await _context.Ordenes.ToListAsync());
        }

        // GET: Ordenes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Ordenes == null)
            {
                return NotFound();
            }

            var orden = await _context.Ordenes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (orden == null)
            {
                return NotFound();
            }

            return View(orden);
        }

        // GET: Ordenes/Create
        public IActionResult Create()
        {
            ViewBag.Acciones = _context.Acciones.ToList();
            ViewBag.Usuarios = _context.Usuarios.ToList();
            return View();
        }

        // POST: Ordenes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(int AccionId,int UsuarioId, [Bind("Id,Cantidad,PrecioCompra,EsCompra")] Orden orden)
        {
            orden.Accion = _context.Acciones.Find(AccionId);
            orden.FechaCompra = DateTime.Now;
            Usuario usuario = _context.Usuarios.Find(UsuarioId);
            //Si el precio de la accion * la cantidad no es igual al precio de compra * la cantidad entonces te devuelve al indice y no carga la orden
            if((orden.Accion.Precio * orden.Cantidad) != (orden.PrecioCompra * orden.Cantidad))
            {
                return RedirectToAction(nameof(Index));
            }
            else 
            {
                usuario.Ordenes.Add(orden);
                _context.Add(orden);
                _context.Update(usuario);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));

            }

            return View(orden);
        }

        // GET: Ordenes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Ordenes == null)
            {
                return NotFound();
            }

            var orden = await _context.Ordenes.FindAsync(id);
            if (orden == null)
            {
                return NotFound();
            }
            return View(orden);
        }

        // POST: Ordenes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,PrecioCompra,Cantidad,FechaCompra,EsCompra")] Orden orden)
        {
            if (id != orden.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(orden);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OrdenExists(orden.Id))
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
            return View(orden);
        }

        // GET: Ordenes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Ordenes == null)
            {
                return NotFound();
            }

            var orden = await _context.Ordenes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (orden == null)
            {
                return NotFound();
            }

            return View(orden);
        }

        // POST: Ordenes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Ordenes == null)
            {
                return Problem("Entity set 'Broker_Context.Ordenes'  is null.");
            }
            var orden = await _context.Ordenes.FindAsync(id);
            if (orden != null)
            {
                _context.Ordenes.Remove(orden);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OrdenExists(int id)
        {
          return _context.Ordenes.Any(e => e.Id == id);
        }
    }
}
