using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Ejecuciones.Models
{
    public class Fallador
    {
        [Key]
        public int FalladorId { get; set; }

        [Required(ErrorMessage = "Seleccione Departamento")]
        [Display(Name = "Departamento")]
        public int DepartamentoId { get; set; }

        [Required(ErrorMessage = "Seleccione Municipio")]
        [Display(Name = "Municipio")]
        public int MunicipioId { get; set; }

        [Required(ErrorMessage = "Nombre Juzgado requerido")]
        [StringLength(200, ErrorMessage = "Máximo 200 caracteres")]
        [Display(Name = "Juzgado")]
        public string JuzgadoFallador { get; set; }

        //Relaciones
        public virtual Departamento Departamento { get; set; }
        public virtual Municipio Municipio { get; set; }
    }
}
