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
    public class AsignacionController : Controller
    {
        private readonly AcademySystemContext _context;

        public AsignacionController(AcademySystemContext context)
        {
            _context = context;
        }

        // GET: Asignacion
        public async Task<IActionResult> Index()
        {
            var academySystemContext = _context.Asignacion.Include(a => a.Curso).Include(a => a.Instructor);
            return View(await academySystemContext.ToListAsync());
        }

        // GET: Asignacion/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var asignacion = await _context.Asignacion
                .Include(a => a.Curso)
                .Include(a => a.Instructor)
                .FirstOrDefaultAsync(m => m.AsignacionID == id);
            if (asignacion == null)
            {
                return NotFound();
            }

            return View(asignacion);
        }

        // GET: Asignacion/Create
        public IActionResult Create()
        {
            ViewData["CursoID"] = new SelectList(_context.Set<Curso>(), "CursoID", "CursoID");
            ViewData["InstructorID"] = new SelectList(_context.Set<Instructor>(), "InstructorID", "InstructorID");
            return View();
        }

        // POST: Asignacion/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AsignacionID,CursoID,InstructorID,Fecha")] Asignacion asignacion)
        {
            if (ModelState.IsValid)
            {
                _context.Add(asignacion);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CursoID"] = new SelectList(_context.Set<Curso>(), "CursoID", "CursoID", asignacion.CursoID);
            ViewData["InstructorID"] = new SelectList(_context.Set<Instructor>(), "InstructorID", "InstructorID", asignacion.InstructorID);
            return View(asignacion);
        }

        // GET: Asignacion/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var asignacion = await _context.Asignacion.FindAsync(id);
            if (asignacion == null)
            {
                return NotFound();
            }
            ViewData["CursoID"] = new SelectList(_context.Set<Curso>(), "CursoID", "CursoID", asignacion.CursoID);
            ViewData["InstructorID"] = new SelectList(_context.Set<Instructor>(), "InstructorID", "InstructorID", asignacion.InstructorID);
            return View(asignacion);
        }

        // POST: Asignacion/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("AsignacionID,CursoID,InstructorID,Fecha")] Asignacion asignacion)
        {
            if (id != asignacion.AsignacionID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(asignacion);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AsignacionExists(asignacion.AsignacionID))
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
            ViewData["CursoID"] = new SelectList(_context.Set<Curso>(), "CursoID", "CursoID", asignacion.CursoID);
            ViewData["InstructorID"] = new SelectList(_context.Set<Instructor>(), "InstructorID", "InstructorID", asignacion.InstructorID);
            return View(asignacion);
        }

        // GET: Asignacion/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var asignacion = await _context.Asignacion
                .Include(a => a.Curso)
                .Include(a => a.Instructor)
                .FirstOrDefaultAsync(m => m.AsignacionID == id);
            if (asignacion == null)
            {
                return NotFound();
            }

            return View(asignacion);
        }

        // POST: Asignacion/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var asignacion = await _context.Asignacion.FindAsync(id);
            _context.Asignacion.Remove(asignacion);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AsignacionExists(int id)
        {
            return _context.Asignacion.Any(e => e.AsignacionID == id);
        }
    }
}
