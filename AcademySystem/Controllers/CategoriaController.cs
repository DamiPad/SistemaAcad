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
    public class CategoriaController : Controller
    {
        private readonly AcademySystemContext _context;

        public CategoriaController(AcademySystemContext context)
        {
            _context = context;
        }

        // GET: Categoria
        public async Task<IActionResult> Index(string sortOrder, string searchString,string currentFilter, int? page)
        {
            ViewData["NombreSortParam"] = String.IsNullOrEmpty(sortOrder) ? "nombr_desc" : "";
            ViewData["DescripcionSortParam"] = sortOrder == "descripcion_asc" ? "descripcion_desc" : "descripcion_asc";
            ViewData["CarreraSortParm"] = sortOrder == "carrera_asc" ? "carrera_desc" : "carrera_asc";

            var categorias = from s in _context.Categoria select s;
            if (searchString != null)
                page = 1;
            else
            {
                searchString = currentFilter;
                ViewData["CurrentFilter"] = searchString;
                ViewData["CurrentSort"] = sortOrder;

            }



                if (!String.IsNullOrEmpty(searchString))
                {
                    categorias = categorias.Where(s => s.Nombre.Contains(searchString) || s.Descripcion.Contains(searchString));
                }
                switch (sortOrder)
                {
                    case "nombre_desc":
                        categorias = categorias.OrderByDescending(s => s.Nombre);
                        break;
                    case "descripcion_desc":
                        categorias = categorias.OrderBy(s => s.Descripcion);
                        break;
                    case "descripcion_asc":
                        categorias = categorias.OrderByDescending(s => s.Descripcion);
                        break;
                    case "carrera_desc":
                        categorias = categorias.OrderBy(s => s.Carrera);
                        break;
                    case "carrera_asc":
                        categorias = categorias.OrderByDescending(s => s.Carrera);
                        break;
                    default:
                        categorias = categorias.OrderBy(s => s.Nombre);
                        break;
                }
            
            int pageSize = 3;
            return View(await Paginacion<Categoria>.CreateAsync(categorias.AsNoTracking(), page ?? 1, pageSize));

            //return View(await categorias.AsNoTracking().ToListAsync());
        }

        // GET: Categoria/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var categoria = await _context.Categoria
                .FirstOrDefaultAsync(m => m.CategoriaID == id);
            if (categoria == null)
            {
                return NotFound();
            }

            return View(categoria);
        }

        // GET: Categoria/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Categoria/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CategoriaID,Nombre,Descripcion,Carrera,Estado")] Categoria categoria)
        {
            if (ModelState.IsValid)
            {
                _context.Add(categoria);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(categoria);
        }

        // GET: Categoria/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var categoria = await _context.Categoria.FindAsync(id);
            if (categoria == null)
            {
                return NotFound();
            }
            return View(categoria);
        }

        // POST: Categoria/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CategoriaID,Nombre,Descripcion,Carrera,Estado")] Categoria categoria)
        {
            if (id != categoria.CategoriaID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(categoria);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CategoriaExists(categoria.CategoriaID))
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
            return View(categoria);
        }

        // GET: Categoria/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var categoria = await _context.Categoria
                .FirstOrDefaultAsync(m => m.CategoriaID == id);
            if (categoria == null)
            {
                return NotFound();
            }

            return View(categoria);
        }

        // POST: Categoria/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var categoria = await _context.Categoria.FindAsync(id);
            _context.Categoria.Remove(categoria);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CategoriaExists(int id)
        {
            return _context.Categoria.Any(e => e.CategoriaID == id);
        }
    }
}
