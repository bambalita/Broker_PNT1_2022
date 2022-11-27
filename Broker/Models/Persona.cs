using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Broker.Models
{
    public class Persona
    {
        [Key]
        public int ID { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 2)]
        public string Nombre { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 2)]
        public string Apellido { get; set; }

        [Required]
        [EmailAddress]
        public string Mail { get; set; }

        [ForeignKey ("direccionID")]
        public Direccion Direccion { get; set; }

        [RegularExpression(@"[0-9]{2}[0-9]{4}[0-9]{4}")]
        public string Telefono { get; set; }

        [Required]
        [Range(1,100000000, ErrorMessage = "El valor debe estar entre 1 y 100000000")]
        public long DNI { get; set; }

        public string NombreCompletoConID()
        {
            return ID + "." + Nombre + " " + Apellido;
        }
    }
}
