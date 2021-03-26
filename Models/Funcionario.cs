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
        [Required(ErrorMessage ="Nombre(s) requerido")]
        [StringLength(200,ErrorMessage ="Máximo 200 caracteres")]
        [Display(Name ="Nombre(s):")]
        public string Nombres{ get; set; }
        [Required(ErrorMessage = "Apellido(s) requerido")]
        [StringLength(200, ErrorMessage = "Máximo 200 caracteres")]
        [Display(Name = "Apellido(s):")]
        public string Apellidos { get; set; }

        public int DespachoId { get; set; }
        public virtual Despacho Despacho { get; set; }

    }
}
