using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Ejecuciones.Models
{
    [Table("despachos")]
    public class Despacho
    {
        [Key]
        public int DespachoId { get; set; }
        [Required (ErrorMessage ="Campo Requerido")]
        [StringLength(50,ErrorMessage ="50 caracteres máximo")]
        public string NombreDespacho { get; set; }

        public virtual ICollection<Funcionario> Funcionarios { get; set; }
    }
}
