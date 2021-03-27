using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Ejecuciones.Models
{
    [Table ("TiposSolicitud")]
    public class TipoSolicitud
    {
        [Key]
        public int TipoSolicitudId { get; set; }

        [StringLength(30, ErrorMessage = "30 caracteres máximo")]
        [Required(ErrorMessage = "Nombre Requerido")]
        [Display(Name = "Solicitud:")]
        public string NombreSolicitud { get; set; }
    }
}
