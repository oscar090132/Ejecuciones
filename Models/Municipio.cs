using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Ejecuciones.Models
{
    [Table("municipios")]
    public class Municipio : IValidatableObject
    {

        [Required(ErrorMessage ="Departamento Requerido")]
        public string CodigoDepartamento;
        public Departamento Departamento { get; set; }
        [StringLength(3,ErrorMessage ="Longitud máxima 3")]
        [Required]
        public string CodigoMunicipio { get; set; }
        public string Nombre { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {

            Regex reg = new Regex("[0-9]"); //Expresión que solo acepta números.

            if (!reg.IsMatch(CodigoMunicipio))
            {
                yield return new ValidationResult("El código deben ser dos carateres numericos", new string[] { nameof(CodigoMunicipio) });
            }
            if (CodigoMunicipio.Trim().Length != 3)
            {
                yield return new ValidationResult("El código deben ser dos carateres numericos", new string[] { nameof(CodigoMunicipio) });
            }

        }
    }
    
}
