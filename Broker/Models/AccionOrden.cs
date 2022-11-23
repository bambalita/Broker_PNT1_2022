namespace Broker.Models
{
    public class AccionOrden
    {
        public string NombreEmpresa { get; set; }
        public double PrecioAccion { get; set; }
        public int OrdenId { get; set; }
        public int CantidadAccion { get; set; }
        public DateTime FechaCompra { get; set; }
        public bool EsCompra { get; set; }
    }
}
