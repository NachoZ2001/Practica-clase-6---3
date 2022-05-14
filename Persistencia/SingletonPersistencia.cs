using Entidades;
using Newtonsoft.Json;
namespace Persistencia
{
    public sealed class SingletonPersistencia
    {
        private static SingletonPersistencia instance = null;
        private SingletonPersistencia() { }
        public EventHandler<PasarEntidadEventArgs> PasarEntidad;
        public static SingletonPersistencia Instance
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
        string pathJugadores = @"C:\Users\UCSE\Desktop\Jugadores.txt";
        public List<Jugador> LeerJugadores()
        {
            List<Jugador> jugadores = new List<Jugador>();
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
        public void GuardarListadoJugadores(int identificacionEntidad, List<Jugador> jugadores)
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
            if (this.PasarEntidad != null)
            {
                this.PasarEntidad(this, new PasarEntidadEventArgs { IdentificacionEntidad = identificacionEntidad,  Jugadores = jugadores });
            }
        }
        public void GuardarListadoJugadores( List<Jugador> jugadores)
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
}

