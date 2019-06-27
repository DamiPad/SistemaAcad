using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AcademySystem.Models
{
    public class Inscripcion
    {
        [Key]
        public int InscripcionID { get; set; }
        public int Grado { get; set; }
        [Range(typeof(decimal), "6", "2")]
        public decimal Pago { get; set; }
        public DateTime Fecha { get; set; }
        public int CursoID { get; set; }
        //[ForeignKey("CursoID")]
        //public virtual Curso Curso { get; set; }
        public int EstudianteID { get; set; }
        public Estudiante Estudiante { get; set; }
        public Curso Curso { get; set; }
    }
}
