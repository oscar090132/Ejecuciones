using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Ejecuciones.Models
{
    [Table ("Solicitudes")]
    public class Solicitud
    {
        [Key]
        public int SolicitudId { get; set; }

        [Required(ErrorMessage = "Seleccione Despacho")]
        [Display(Name = "Despacho:")]
        public int DespachoId { get; set; }

        [Required(ErrorMessage = "Seleccione Solicitud")]
        [Display(Name = "Solicitud:")]
        public int TipoSolicitudId { get; set; }

        public DateTime FechaSolicitud { get; set; }

        [Required(ErrorMessage = "Cedula Requerida")]
        [StringLength(10, ErrorMessage = "Máximo 10 caracteres")]
        [Display(Name = "Cedula Condenado:")]
        public string CedulaCondenado { get; set; }

        [Required(ErrorMessage = "Nombre(s) requerido")]
        [StringLength(200, ErrorMessage = "Máximo 200 caracteres")]
        [Display(Name = "Nombre(s) Condenado:")]
        public string NombresCondenado { get; set; }

        [Required(ErrorMessage = "Apellido(s) requerido")]
        [StringLength(200, ErrorMessage = "Máximo 200 caracteres")]
        [Display(Name = "Apellido(s) Condenado:")]
        public string ApellidosCondenado { get; set; }

        public string AnexosSolicitud { get; set; }

        [Required(ErrorMessage = "Cuadernos requerido")]
        [StringLength(2, ErrorMessage = "Máximo 2 caracteres")]
        [Display(Name = "Cuadernos:")]
        public string CuadernosSolicitud { get; set; }

        [Required(ErrorMessage = "Folios requerido")]
        [StringLength(2, ErrorMessage = "Máximo 2 caracteres")]
        [Display(Name = "Folios:")]
        public string FoliosSolicitud { get; set; }

        public int EstadoSolicitudId { get; set; }

        //Relaciones
        public virtual Despacho Despacho { get; set; }
        public virtual TipoSolicitud TipoSolicitud { get; set; }
        public virtual EstadoSolicitud EstadoSolicitud { get; set; }
    }
}
