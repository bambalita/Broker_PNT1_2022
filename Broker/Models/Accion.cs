using System.ComponentModel.DataAnnotations;

namespace Broker.Models
{
    public class Accion
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Empresa { get; set; }

        [Required]
        public double Precio { get; set; }

        public string EmpresaPrecio() 
        {
            return Empresa + ": $" + Precio.ToString();
        }

    }
}
