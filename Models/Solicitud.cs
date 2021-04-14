using Microsoft.AspNetCore.Http;
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
        [Display(Name = "Solicitud")]
        public int SolicitudId { get; set; }

        [Required(ErrorMessage = "Seleccione Despacho")]
        [Display(Name = "Despacho")]
        public int DespachoId { get; set; }

        [Required(ErrorMessage = "Seleccione Solicitud")]
        [Display(Name = "Solicitud")]
        public int TipoSolicitudId { get; set; }

        [Display(Name = "Fecha")] 
        public DateTime FechaSolicitud { get; set; }

        [Required(ErrorMessage = "Cedula Requerida")]
        [StringLength(10, ErrorMessage = "Máximo 10 caracteres")]
        [Display(Name = "Condenado")]
        public string CedulaCondenado { get; set; }

        [Required(ErrorMessage = "Nombre(s) requerido")]
        [StringLength(200, ErrorMessage = "Máximo 200 caracteres")]
        [Display(Name = "Nombre(s)")]
        public string NombresCondenado { get; set; }

        [Required(ErrorMessage = "Apellido(s) requerido")]
        [StringLength(200, ErrorMessage = "Máximo 200 caracteres")]
        [Display(Name = "Apellido(s)")]
        public string ApellidosCondenado { get; set; }

        [Required(ErrorMessage = "No ha seleccionado ningun archivo")]
        [Display(Name = "Archivos PDF")]
        [NotMapped]
        public IFormFile SolicitudPdf { get; set; }
        public string AnexosSolicitud { get; set; }

        
        [Required(ErrorMessage = "Cuadernos requerido")]
        [StringLength(2, ErrorMessage = "Máximo 2 caracteres")]
        [Display(Name = "Cuadernos")]
        public string CuadernosSolicitud { get; set; }

        [Required(ErrorMessage = "Folios requerido")]
        [StringLength(2, ErrorMessage = "Máximo 2 caracteres")]
        [Display(Name = "Folios")]
        public string FoliosSolicitud { get; set; }

        public int EstadoSolicitudId { get; set; }

        //Relaciones
        public virtual Despacho Despacho { get; set; }
        public virtual TipoSolicitud TipoSolicitud { get; set; }
        public virtual EstadoSolicitud EstadoSolicitud { get; set; }
    }
}
