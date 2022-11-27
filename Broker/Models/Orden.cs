using System.ComponentModel;
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
        public int Cantidad { get; set; }
        [Required]
        public Accion Accion { get; set; }
        [Required]
        public DateTime FechaCompra { get; set; }
        [Required]
        [DisplayName("Compra")]
        public Boolean EsCompra { get; set; }

        public string EmpresaPrecio() 
        {
            return Accion.EmpresaPrecio();
        }


    }
}
