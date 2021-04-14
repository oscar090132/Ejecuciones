using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Ejecuciones.Models
{
    [Table("cargos") ]
    public class CargoEmpleado
    {
        [Key]
        public int CargoId { get; set; }

        [StringLength(30, ErrorMessage = "30 caracteres máximo")]
        [Required(ErrorMessage = "Nombre Requerido")]
        [Display(Name = "Nombre Cargo")]
        public string NombreCargo { get; set; }
    }
}
