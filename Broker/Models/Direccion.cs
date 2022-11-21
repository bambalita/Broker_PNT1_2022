using System.ComponentModel.DataAnnotations;

namespace Broker.Models
{
    public class Direccion
    {
        [Key]
        public int ID { get; set; }
        [Required]
        [StringLength(50)]
        public string Pais { get; set; }
        [Required]
        [StringLength(50)]
        public string Provincia { get; set; }
        [Required]
        [StringLength(50)]
        public string  Ciudad { get; set; }
        [Required]
        [StringLength(100)]
        public string Calle { get; set; }
        [Required]
        public int Numero { get; set; }
        
        public string Departamento { get; set; }

        public string DireccionCompleta() 
        {
            return Calle + " " + Numero + ", " + Departamento + ", " + Ciudad + ", " + Provincia + ", " + Pais;
        }
    }
}