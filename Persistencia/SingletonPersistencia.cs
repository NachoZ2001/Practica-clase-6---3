using Entidades;
using Newtonsoft.Json;
namespace Persistencia
{
    public sealed class SingletonPersistencia
    {
        public List<Jugador> jugadores = null;
        private static SingletonPersistencia instance = null;
        private SingletonPersistencia() { }
        public static SingletonPersistencia ReturnInstance
        {
            get
            {
                if (instance == null)
                {
                    instance = new SingletonPersistencia();
                }
                return instance;
            }
        }
        string pathJugadores = "";
        public List<Jugador> LeerJugadores()
        {
            if (File.Exists(pathJugadores))
            {
                using (StreamReader reader = new StreamReader(pathJugadores))
                {
                    string jugador = reader.ReadToEnd();
                    if (jugador != "")
                    {
                        jugadores = JsonConvert.DeserializeObject<List<Jugador>>(jugador);
                    }
                }
            }
            return jugadores;
        }
        public void GuardarListadoJugadores(List<Jugador> jugadores)
        {
            if (!File.Exists(pathJugadores))
            {
                File.Create(pathJugadores);
                using (StreamWriter writer = new StreamWriter(pathJugadores))
                {
                    string jugadorJson = JsonConvert.SerializeObject(jugadores);
                    writer.Write(jugadorJson);
                }
            }
            else
            {
                using (StreamWriter writer = new StreamWriter(pathJugadores, false))
                {
                    string jugadorJson = JsonConvert.SerializeObject(jugadores);
                    writer.Write(jugadorJson);
                }
            }
            }
        }
        public static void DarAltaJugadorHandler(object? sender, DarAltaJugadorEventArgs jugador)
        {           
            if (jugadores == null)
            {
                jugadores = new List<Jugador>();               
            }
            jugadores.Add(jugador);
        }
        public static void ModificarJugador(object? sender, ModificarJugadorEventArgs datosModificar)
        {
            if (jugadores == null)
            {
                throw new Exception("No hay ningun jugador registrado");
            }
            else
            {
                Jugador jugador = jugadores.Find(x => x.Identificacion == datosModificar.Identificacion);
                if (datosModificar.NumeroCamiseta != 0)
                {
                    jugador.NumeroCamiseta = datosModificar.NumeroCamiseta;
                }
                if (datosModificar.Sueldo != 0)
                {
                    jugador.Sueldo = datosModificar.Sueldo;
                }
            }           
        }
        public static void DarBajaJugadorHandler(object? sender, DarBajaJugadorEventArgs identificacion)
        {
            if (jugadores == null)
            {
                throw new Exception("No hay ningun jugador registrado");
            }
            else
            {
                jugadores.Remove(jugadores.Find(x => x.Identificacion == identificacion.IdentificacionJugador));
            }            
        }
    }
}