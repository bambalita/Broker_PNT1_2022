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
    public class UsuariosController : Controller
    {
        private readonly Broker_Context _context;

        public UsuariosController(Broker_Context context)
        {
            _context = context;
        }

        // GET: Usuarios
        public async Task<IActionResult> Index()
        {
              return View(await _context.Usuarios.ToListAsync());
        }

        // GET: Usuarios/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Usuarios == null)
            {
                return NotFound();
            }

            var usuario = await _context.Usuarios
                .FirstOrDefaultAsync(m => m.ID == id);
            if (usuario == null)
            {
                return NotFound();
            }

            return View(usuario);
        }

        // GET: Usuarios/Create
        public IActionResult Create()
        {
            
            if (TempData["direccion"] == null)
            {
                return RedirectToAction("Create", "Direcciones");
            }
            else 
            {
                TempData["dirID"] = TempData["direccion"];
                return View();
            }
            
        }

        // POST: Usuarios/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Nombre,Apellido,Mail,Telefono,DNI,Direccion")] Usuario usuario)
        {
            usuario.Direccion = _context.Direcciones.Find(TempData["dirID"]);
            usuario.CantDinero = 0;
            //agrega el usuario
            _context.Add(usuario);
            //le hace un update a la direccion del usuario
            _context.Update(usuario.Direccion);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));

        }

        // GET: Usuarios/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Usuarios == null)
            {
                return NotFound();
            }

            var usuario = await _context.Usuarios.FindAsync(id);
            if (usuario == null)
            {
                return NotFound();
            }
            return View(usuario);
        }

        // POST: Usuarios/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CantDinero,ID,Nombre,Apellido,Mail,Telefono,DNI")] Usuario usuario)
        {
            if (id != usuario.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(usuario);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UsuarioExists(usuario.ID))
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
            return View(usuario);
        }

        // GET: Usuarios/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Usuarios == null)
            {
                return NotFound();
            }

            var usuario = await _context.Usuarios
                .FirstOrDefaultAsync(m => m.ID == id);
            if (usuario == null)
            {
                return NotFound();
            }

            return View(usuario);
        }

        // POST: Usuarios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Usuarios == null)
            {
                return Problem("Entity set 'Broker_Context.Usuarios'  is null.");
            }
            var usuario = await _context.Usuarios.FindAsync(id);
            if (usuario != null)
            {
                _context.Usuarios.Remove(usuario);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Depositar() 
        {
            ViewBag.listaUsuarios = _context.Usuarios.ToList();
            return View();
        }

        [HttpPost]
        public IActionResult Depositar(int id, int CantDinero)
        {
            Usuario usuario = _context.Usuarios.Find(id);
            if (CantDinero != 0)
            {
                usuario.CantDinero += CantDinero;
                _context.Update(usuario);
                _context.SaveChangesAsync();
            }
            return RedirectToAction("Index");

        }
        public IActionResult Extraer()
        {
            ViewBag.listaUsuarios = _context.Usuarios.ToList();
            return View();
        }

        [HttpPost]
        public IActionResult Extraer(int id, int CantDinero)
        {
            Usuario usuario = _context.Usuarios.Find(id);
            if (usuario.esCantDineroValido(CantDinero))
            {
                usuario.CantDinero -= CantDinero;
                _context.Update(usuario);
                _context.SaveChangesAsync();
            }
            return RedirectToAction("Index");

        }

        public async Task<IActionResult> Cartera(int id)
        {
            IEnumerable<Orden> ordenes = _context.Ordenes.Where(o => o.Id == id);
            ViewBag.NombreCompleto = _context.Usuarios.Find(id).NombreCompletoConID();
            return View(ordenes);

        }
        private bool UsuarioExists(int id)
        {
          return _context.Usuarios.Any(e => e.ID == id);
        }
    }
}
