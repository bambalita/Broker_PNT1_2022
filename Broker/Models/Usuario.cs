namespace Broker.Models
{
    public class Usuario : Persona
    {
        public double CantDinero {get; set;}

        public List<Accion> Acciones {get; set;} = new List<Accion> { };

        public List<Orden> Ordenes {get; set;} = new List<Orden> { };

        public bool esCantDineroValido(int cant) 
        {
            bool resul = false;

            if ((this.CantDinero - cant) > 0) 
            {
                resul = true;
            }
            return resul;
        }

        public string DireccionCompleta() 
        {
            return this.Direccion.DireccionCompleta();
        }
    }
}
