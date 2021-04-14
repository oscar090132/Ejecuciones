using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Ejecuciones.Models
{
    [Table ("EstadosProceso")]
    public class EstadoProceso
    {
        [Key]
        public int EstadoProcesoId { get; set; }

        [StringLength(100, ErrorMessage = "100 caracteres máximo")]
        [Required(ErrorMessage = "Nombre Requerido")]
        [Display(Name = "Estado")]
        public string NombreEstadoProceso { get; set; }

    }
}
