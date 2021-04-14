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
        [Key]
        public int MunicipioId { get; set; }
        
        [StringLength(3,ErrorMessage ="3 caracteres numéricos")]
        [Required(ErrorMessage = "Código Requerido")]
        [Display(Name = "Codigo Municipio")]
        public string CodigoMunicipio { get; set; }
        
        [StringLength(30, ErrorMessage = "30 caracteres máximo")]
        [Required(ErrorMessage = "Nombre Requerido")]
        [Display(Name = "Nombre Municipio")]
        public string NombreMunicipio { get; set; }

        public int DepartamentoId { get; set; }
        
        public virtual Departamento Departamento { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            Regex reg = new Regex("[0-9]"); //Expresión que solo acepta números.

            if (!reg.IsMatch(CodigoMunicipio))
            {
                yield return new ValidationResult("El código deben ser tres carateres numéricos", new string[] { nameof(CodigoMunicipio) });
            }
            if (CodigoMunicipio.Trim().Length != 3)
            {
                yield return new ValidationResult("El código deben ser tres carateres numéricos", new string[] { nameof(CodigoMunicipio) });
            }
        }
    }
}
