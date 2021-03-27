using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Ejecuciones.Models
{
    [Table ("EstadosSolicitud")]
    public class EstadoSolicitud
    {
        [Key]
        public int EstadoSolicitudId { get; set; }

        [StringLength(100, ErrorMessage = "100 caracteres máximo")]
        [Required(ErrorMessage = "Nombre Requerido")]
        [Display(Name = "Estado:")]
        public string NombreEstadoSolicitud { get; set; }

    }
}
