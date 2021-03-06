using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Ejecuciones.Models
{
    [Table ("Procesos")]
    public class Proceso
    {
        [Key]
        public int ProcesoId { get; set; }

        public int DespachoId { get; set; }

        public DateTime FechaProceso { get; set; }

        [Required(ErrorMessage = "Radicado del Proceso Requerido")]
        [MinLength(23, ErrorMessage = "Los 23 Dígitos del Radicado deben ser Digitados")]
        [Display(Name = "Radicado Proceso:")]
        public string RadicadoProceso { get; set; }

        [Required(ErrorMessage = "Seleccione Juzgado Fallador")]
        [Display(Name = "Juzgado Fallador:")]
        public int FalladorId { get; set; }

        public string AnexosSolicitud { get; set; }

        [Required(ErrorMessage = "Cuadernos requerido")]
        [StringLength(2, ErrorMessage = "Máximo 2 caracteres")]
        [Display(Name = "Cuadernos:")]
        public string CuadernosProceso { get; set; }

        [Required(ErrorMessage = "Folios requerido")]
        [StringLength(2, ErrorMessage = "Máximo 2 caracteres")]
        [Display(Name = "Folios:")]
        public string FoliosProceso { get; set; }

        public int EstadoProcesoId { get; set; }

        //Relaciones
        public virtual Despacho Despacho { get; set; }
        public virtual Fallador Fallador { get; set; }
        public virtual EstadoProceso EstadoProceso { get; set; }

    }
}
