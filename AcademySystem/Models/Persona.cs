using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AcademySystem.Models
{
    public class Persona
    {
        [Key]
        public int PersonaID { get; set; }
        [StringLength(30, ErrorMessage = "Solo se permiten 30 caracteres")]
        public string Apellidos { get; set; }
        [StringLength(20, ErrorMessage = "Solo se permiten 20 caracteres")]
        public string Nombres { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string Documento { get; set; }
        [StringLength(50, ErrorMessage = "Solo se permiten 50 caracteres")]
        public string Email { get; set; }
        [StringLength(10, ErrorMessage = "Solo se permiten 10 dígitos")]
        public string Telefono { get; set; }
        [StringLength(50, ErrorMessage = "Excedio el tamaño permitido")]
        public string Direccion { get; set; }
        public Boolean Estado { get; set; }
    }
}
