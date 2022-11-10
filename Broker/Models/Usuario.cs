namespace Broker.Models
{
    public class Usuario : Persona
    {
        public double CantDinero {get; set;}

        public List<Accion> acciones {get; set;}

        public List<Orden> ordenes {get; set;}



    }
}
