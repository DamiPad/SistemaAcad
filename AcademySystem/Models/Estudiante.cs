using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AcademySystem.Models
{
    public class Estudiante
    {
        [Key]
        public int EstudianteID { get; set; }
        [StringLength(20, ErrorMessage = "Máximo de 20 caracteres")]
        public string Codigo { get; set; }

        public int PersonaID { get; set; }
        public Persona persona { get; set; }
    }
}
