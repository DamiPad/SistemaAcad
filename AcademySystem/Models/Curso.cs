using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AcademySystem.Models
{
    public class Curso
    {
        [Key]
        public int CursoID { get; set; }
        [StringLength(50, ErrorMessage = "Solo se permiten 50 caracteres")]
        public string Nombre { get; set; }
        public int CategoriaID { get; set; }
        //[ForeignKey("CategoriaID")]
        //public virtual Categoria Categoria { get; set; }
        [StringLength(512, ErrorMessage = "Solo se permiten 512 caracteres")]
        public string Description { get; set; }
        public Byte Creditos { get; set; }
        public Byte Horas { get; set; }
        public Decimal Costo { get; set; }
        public Boolean Estado { get; set; }

        public Categoria Categoria { get; set; }
    }
}
