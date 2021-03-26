using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Ejecuciones.Models
{
    [Table("departamentos")]
    public class Departamento : IValidatableObject
    {
        [Key]
        public int DepartamentoId { get; set; }
        [StringLength(2)]
        [Required(ErrorMessage = "Código Requerido")]
        [Display(Name = "Codigo Departamento:")]
        public string CodigoDepartamento { get; set; }
        [MaxLength(30)]
        [Required(ErrorMessage="Nombre Requerido")]
        [Display(Name = "Nombre Departamento:")]
        public string Nombre { get; set; }
        public virtual ICollection<Municipio> Municipios { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            Regex reg = new Regex("[0-9]"); //Expresión que solo acepta números.

            if (!reg.IsMatch(CodigoDepartamento))
            {
                yield return new ValidationResult("El código deben ser dos carateres numericos", new string[] { nameof(CodigoDepartamento) });
            }
            if (CodigoDepartamento.Trim().Length!=2)
            {
                yield return new ValidationResult("El código deben ser dos carateres numericos", new string[] { nameof(CodigoDepartamento) });
            }

        }
    }
}
