using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AcademySystem.Models
{
    public class Categoria
    {
        [Key]
        public int CategoriaID { get; set; }
        [Required(ErrorMessage = "Obligatorio")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "El nombre  debe tener de 3 a 50 letras")]
        public string Nombre { get; set; }
        [StringLength(256, ErrorMessage = "Maximo 256 letras")]
        [Display(Name = "Descripcion")]
        public string Descripcion { get; set; }
        [StringLength(58, ErrorMessage = "El nombre  debe tener 58 caracteres")]
        public string Carrera { get; set; }
        public Boolean Estado { get; set; }
    }
}
