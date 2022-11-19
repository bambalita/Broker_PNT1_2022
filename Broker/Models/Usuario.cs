namespace Broker.Models
{
    public class Usuario : Persona
    {
        public double CantDinero {get; set;}

        public List<Accion> Acciones {get; set;} = new List<Accion> { };

        public List<Orden> Ordenes {get; set;} = new List<Orden> { };

    }
}
