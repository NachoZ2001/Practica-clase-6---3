using Entidades;
using Persistencia;
namespace Logica
{
    public sealed class SingletonLogica
    {
        private static SingletonLogica instance = null;
        private SingletonLogica() { }

        public static SingletonLogica Instance
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
        public EventHandler<ImprimirEntidadEventArgs> ImprimirEntidad;
        public List<Jugador> jugadores;

        public void DarAltaJugador(int edad, int numeroCamiseta, double sueldo, double estatura)
        {
            jugadores = LeerListaJugadores();
            int identificacion = 1;
            if (jugadores != null)
            {
                identificacion = jugadores.Count + 1;
            }
            Jugador nuevoJugador = new Jugador(identificacion, edad, numeroCamiseta, sueldo, estatura);
            jugadores.Add(nuevoJugador);
            GuardarListaJugadores(identificacion, jugadores);
        }

        public void DarBajaJugador(int identificacion)
        {
            jugadores = LeerListaJugadores();
            if (jugadores != null)
            {
                jugadores.Remove(jugadores.Find(x => x.Identificacion == identificacion));
            }
            GuardarListaJugadores(jugadores);
        }

        public void ModificarJugador(int identificacion, int numeroCamiseta = 0, double sueldo = 0)
        {
            jugadores = LeerListaJugadores();
            if (jugadores != null)
            {
                Jugador jugadorModificar = jugadores.Find(x => x.Identificacion == identificacion);
                if (numeroCamiseta != 0)
                {
                    jugadorModificar.NumeroCamiseta = numeroCamiseta;
                }
                if (sueldo != 0)
                {
                    jugadorModificar.Sueldo = sueldo;
                }
            }
            GuardarListaJugadores(identificacion, jugadores);
        }
        public void PasarEntidadHandler(object? sender, PasarEntidadEventArgs entidad)
        {
            if (this.ImprimirEntidad != null)
            {
                Jugador jugador = entidad.Jugadores.Find(x => x.Identificacion == entidad.IdentificacionEntidad);
                if (jugador != null)
                {
                    this.ImprimirEntidad(this, new ImprimirEntidadEventArgs { Identificacion = jugador.Identificacion, NumeroCamiseta = jugador.NumeroCamiseta, Edad = jugador.Edad, Sueldo = jugador.Sueldo, Estatura = jugador.Estatura });
                }                
            }
        }

        public List<Jugador> LeerListaJugadores()
        {
            return SingletonPersistencia.Instance.LeerJugadores();
        }
        public void GuardarListaJugadores(int identificacionEntidad, List<Jugador> jugadores)
        {
            SingletonPersistencia.Instance.GuardarListadoJugadores(identificacionEntidad, jugadores);
        }
        public void GuardarListaJugadores(List<Jugador> jugadors)
        {
            SingletonPersistencia.Instance.GuardarListadoJugadores(jugadores);
        }
    }
    
}