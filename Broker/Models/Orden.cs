using System.ComponentModel.DataAnnotations;

namespace Broker.Models
{
    public class Orden
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public double PrecioCompra { get; set; }
        [Required]
        public int cantidad { get; set; }
        [Required]
        public Accion Accion { get; set; }
        [Required]
        public DateTime FechaCompra { get; set; }
        [Required]
        public Boolean EsCompra { get; set; }


    }
}
