using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AcademySystem.Models
{
    public class Instructor
    {
        [Key]
        public int InstructorID { get; set; }
        [StringLength(30, ErrorMessage = "Solo 30 caracteres, porfi")]
        public string Especialidad { get; set; }

        public int PersonaID { get; set; }
        public Persona persona { get; set; }
    }
}
