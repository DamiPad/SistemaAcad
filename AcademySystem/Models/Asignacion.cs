using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AcademySystem.Models
{
    public class Asignacion
    {
        [Key]
        public int AsignacionID { get; set; }
        public int CursoID { get; set; }
       // [ForeignKey("CursoID")]
       // public virtual Curso Curso { get; set; }
        public int InstructorID { get; set; }
       //[ForeignKey("InstructorID")]
        //public virtual Instructor Instructor { get; set; }
        public DateTime Fecha { get; set; }

        public Curso Curso { get; set; }
        public Instructor Instructor { get; set; }
    }
}
