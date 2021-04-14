using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Ejecuciones.Models
{
    [Table("funcionarios")]
    public class Funcionario
    {
        [Key]
        public int FuncionarioId { get; set; }

        [Required(ErrorMessage = "Cédula requerida")]
        [StringLength(10, ErrorMessage = "Máximo 10 caracteres")]
        [Display(Name = "Cedula")]
        public string Cedula { get; set; }

        [Required(ErrorMessage ="Nombre(s) requerido")]
        [StringLength(200,ErrorMessage ="Máximo 200 caracteres")]
        [Display(Name ="Nombre(s)")]
        public string Nombres{ get; set; }
        
        [Required(ErrorMessage = "Apellido(s) requerido")]
        [StringLength(200, ErrorMessage = "Máximo 200 caracteres")]
        [Display(Name = "Apellido(s)")]
        public string Apellidos { get; set; }

        [Required(ErrorMessage = "Despacho requerido")]
        [Display(Name = "Despacho")]
        public int DespachoId { get; set; }

        [Required(ErrorMessage = "Cargo requerido")]
        [Display(Name = "Cargo")]
        public int CargoId { get; set; }

        public virtual Despacho Despacho { get; set; }

        public virtual CargoEmpleado CargoEmpleado { get; set; }

    }
}
