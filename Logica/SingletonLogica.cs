using Entidades;
using Persistencia;
namespace Logica
{
    public sealed class SingletonLogica
    {
        private static SingletonLogica instance = null;
        private SingletonLogica() { }

        public static SingletonLogica ReturnInstance
        {
            get
            {
                if (instance == null)
                {
                    instance = new SingletonLogica();
                }
                return instance;
            }           
        }

        public EventHandler<DarAltaJugadorEventArgs> DarAltaJugadorEventHandler;
        public EventHandler<DarBajaJugadorEventArgs> DarBajaJugadorEventHandler;
        public EventHandler<ModificarJugadorEventArgs> ModificarJugadorEventHandler;
        public EventHandler RetornarJugadores;
        public void DarAltaJugador(int identificacion, int edad, int numeroCamiseta, double sueldo, double estatura)
        {
            Jugador nuevoJugador = new Jugador(identificacion, edad, numeroCamiseta, sueldo, estatura);
            if (this.DarAltaJugadorEventHandler != null)
            {
                this.DarAltaJugadorEventHandler(this, new DarAltaJugadorEventArgs(identificacion, edad, numeroCamiseta, sueldo, estatura) );
            }
        }
        public void DarBajaJugador(int identificacion)
        {          
            if (this.DarBajaJugadorEventHandler != null)
            {
                this.DarBajaJugadorEventHandler(this, new DarBajaJugadorEventArgs(identificacion));
            }
        }
        public void ModificarJugador(int identificacion, int edad = 0, int numeroCamiseta = 0, double sueldo = 0, double estatura = 0)
        {
            if (this.ModificarJugadorEventHandler != null)
            {
                this.ModificarJugadorEventHandler(this, new ModificarJugadorEventArgs());
            }
        }
        public List<Jugador> retornarJugadores()
        {
            if (this.RetornarJugadores != null)
            {
                this.RetornarJugadores(this, new EventArgs());
            }
        }
    }
    
}