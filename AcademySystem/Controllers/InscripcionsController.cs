using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AcademySystem.Models;

namespace AcademySystem.Controllers
{
    public class InscripcionsController : Controller
    {
        private readonly AcademySystemContext _context;

        public InscripcionsController(AcademySystemContext context)
        {
            _context = context;
        }

        // GET: Inscripcions
        public async Task<IActionResult> Index()
        {
            var academySystemContext = _context.Inscripcion.Include(i => i.Curso).Include(i => i.Estudiante);
            return View(await academySystemContext.ToListAsync());
        }

        // GET: Inscripcions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var inscripcion = await _context.Inscripcion
                .Include(i => i.Curso)
                .Include(i => i.Estudiante)
                .FirstOrDefaultAsync(m => m.InscripcionID == id);
            if (inscripcion == null)
            {
                return NotFound();
            }

            return View(inscripcion);
        }

        // GET: Inscripcions/Create
        public IActionResult Create()
        {
            ViewData["CursoID"] = new SelectList(_context.Curso, "CursoID", "CursoID");
            ViewData["EstudianteID"] = new SelectList(_context.Estudiante, "EstudianteID", "EstudianteID");
            return View();
        }

        // POST: Inscripcions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("InscripcionID,Grado,Pago,Fecha,CursoID,EstudianteID")] Inscripcion inscripcion)
        {
            if (ModelState.IsValid)
            {
                _context.Add(inscripcion);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CursoID"] = new SelectList(_context.Curso, "CursoID", "CursoID", inscripcion.CursoID);
            ViewData["EstudianteID"] = new SelectList(_context.Estudiante, "EstudianteID", "EstudianteID", inscripcion.EstudianteID);
            return View(inscripcion);
        }

        // GET: Inscripcions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var inscripcion = await _context.Inscripcion.FindAsync(id);
            if (inscripcion == null)
            {
                return NotFound();
            }
            ViewData["CursoID"] = new SelectList(_context.Curso, "CursoID", "CursoID", inscripcion.CursoID);
            ViewData["EstudianteID"] = new SelectList(_context.Estudiante, "EstudianteID", "EstudianteID", inscripcion.EstudianteID);
            return View(inscripcion);
        }

        // POST: Inscripcions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("InscripcionID,Grado,Pago,Fecha,CursoID,EstudianteID")] Inscripcion inscripcion)
        {
            if (id != inscripcion.InscripcionID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(inscripcion);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!InscripcionExists(inscripcion.InscripcionID))
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
            ViewData["CursoID"] = new SelectList(_context.Curso, "CursoID", "CursoID", inscripcion.CursoID);
            ViewData["EstudianteID"] = new SelectList(_context.Estudiante, "EstudianteID", "EstudianteID", inscripcion.EstudianteID);
            return View(inscripcion);
        }

        // GET: Inscripcions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var inscripcion = await _context.Inscripcion
                .Include(i => i.Curso)
                .Include(i => i.Estudiante)
                .FirstOrDefaultAsync(m => m.InscripcionID == id);
            if (inscripcion == null)
            {
                return NotFound();
            }

            return View(inscripcion);
        }

        // POST: Inscripcions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var inscripcion = await _context.Inscripcion.FindAsync(id);
            _context.Inscripcion.Remove(inscripcion);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool InscripcionExists(int id)
        {
            return _context.Inscripcion.Any(e => e.InscripcionID == id);
        }
    }
}
