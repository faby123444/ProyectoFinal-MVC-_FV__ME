using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProyectoFinal_MVC__FV__ME.Data;
using ProyectoFinal_MVC__FV__ME.Models;

namespace ProyectoFinal_MVC__FV__ME.Controllers
{
    public class Registro_FController : Controller
    {
        private readonly ProyectoFinal_MVC__FV__MEContext _context;

        public Registro_FController(ProyectoFinal_MVC__FV__MEContext context)
        {
            _context = context;
        }

        // GET: Registro_F
        public async Task<IActionResult> Index(string buscar, int filtro)
        {
            var registro_F = from Registro_F in _context.Registro_F select Registro_F;

            if (!String.IsNullOrEmpty(buscar))
            {
                registro_F = registro_F.Where(s => s.Materia!.Contains(buscar));
            }

            if (filtro != 0)
            {
                registro_F = registro_F.Where(s => s.Calificacion == filtro);
                ViewData["FiltroCalificacion"] = filtro;
            }
            else
            {
                ViewData["FiltroCalificacion"] = null;
            }
            registro_F = registro_F.OrderByDescending(s => s.Calificacion);

            return View(await registro_F.ToListAsync());
        }

        // GET: Registro_F/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Registro_F == null)
            {
                return NotFound();
            }

            var registro_F = await _context.Registro_F
                .FirstOrDefaultAsync(m => m.Id == id);
            if (registro_F == null)
            {
                return NotFound();
            }

            return View(registro_F);
        }

        // GET: Registro_F/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Registro_F/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Semestre,Materia,Profesor,Calificacion,Descripcion,Cualidad,Horario")] Registro_F registro_F)
        {
            if (ModelState.IsValid)
            {
                _context.Add(registro_F);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(registro_F);
        }

        // GET: Registro_F/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Registro_F == null)
            {
                return NotFound();
            }

            var registro_F = await _context.Registro_F.FindAsync(id);
            if (registro_F == null)
            {
                return NotFound();
            }
            return View(registro_F);
        }

        // POST: Registro_F/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Semestre,Materia,Profesor,Calificacion,Descripcion,Cualidad,Horario")] Registro_F registro_F)
        {
            if (id != registro_F.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(registro_F);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Registro_FExists(registro_F.Id))
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
            return View(registro_F);
        }

        // GET: Registro_F/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Registro_F == null)
            {
                return NotFound();
            }

            var registro_F = await _context.Registro_F
                .FirstOrDefaultAsync(m => m.Id == id);
            if (registro_F == null)
            {
                return NotFound();
            }

            return View(registro_F);
        }

        // POST: Registro_F/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Registro_F == null)
            {
                return Problem("Entity set 'ProyectoFinal_MVC__FV__MEContext.Registro_F'  is null.");
            }
            var registro_F = await _context.Registro_F.FindAsync(id);
            if (registro_F != null)
            {
                _context.Registro_F.Remove(registro_F);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Registro_FExists(int id)
        {
          return (_context.Registro_F?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
