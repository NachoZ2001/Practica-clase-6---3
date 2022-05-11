namespace Entidades
{
    public class Jugador
    {
        public int Identificacion { get; set; }
        public int Edad { get; set; }
        public int NumeroCamiseta { get; set; }
        public double Sueldo { get; set; }
        public double Estatura { get; set; }

        public Jugador() { }
        public Jugador(int identificacion, int edad, int numeroCamiseta, double sueldo, double estatura)
        {
            this.Identificacion = identificacion;
            this.Edad = edad;
            this.NumeroCamiseta = numeroCamiseta;
            this.Sueldo = sueldo;
            this.Estatura = estatura;
        }
    }
    public class DarAltaJugadorEventArgs : Jugador
    {
        public DarAltaJugadorEventArgs() { }
        public DarAltaJugadorEventArgs(int identificacion, int edad, int numeroCamiseta, double sueldo, double estatura)
        {
            this.Identificacion = identificacion;
            this.Edad = edad;
            this.NumeroCamiseta = numeroCamiseta;
            this.Sueldo = sueldo;
            this.Estatura = estatura;
        }
    }
    public class DarBajaJugadorEventArgs
    {
        public int IdentificacionJugador { get; set; }
        public DarBajaJugadorEventArgs() { }
        public DarBajaJugadorEventArgs(int identificacion)
        {
            this.IdentificacionJugador = identificacion;
        }
    }
    public class ModificarJugadorEventArgs 
    {
        public int Identificacion { get; set; }
        public int NumeroCamiseta { get; set; }
        public double Sueldo { get; set; }
        public ModificarJugadorEventArgs() { }
        public ModificarJugadorEventArgs(int identificacion, int numeroCamiseta, double sueldo)
        {
            this.Identificacion = identificacion;
            this.NumeroCamiseta = numeroCamiseta;
            this.Sueldo = sueldo;
        }
    }
}