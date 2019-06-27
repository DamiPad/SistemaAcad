using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AcademySystem.Models;

namespace AcademySystem.Models
{
    public class AcademySystemContext : DbContext
    {
        public AcademySystemContext (DbContextOptions<AcademySystemContext> options)
            : base(options)
        {
        }

        public DbSet<AcademySystem.Models.Asignacion> Asignacion { get; set; }

        public DbSet<AcademySystem.Models.Categoria> Categoria { get; set; }

        public DbSet<AcademySystem.Models.Curso> Curso { get; set; }

        public DbSet<AcademySystem.Models.Estudiante> Estudiante { get; set; }

        public DbSet<AcademySystem.Models.Inscripcion> Inscripcion { get; set; }

        public DbSet<AcademySystem.Models.Instructor> Instructor { get; set; }

        public DbSet<AcademySystem.Models.Persona> Persona { get; set; }
    }
}
