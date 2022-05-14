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
    public class PasarEntidadEventArgs : EventArgs
    {
        public int IdentificacionEntidad { get; set; }
        public List<Jugador> Jugadores { get; set; }
    }
    public class ImprimirEntidadEventArgs : EventArgs
    {
        public int Identificacion { get; set; }
        public int NumeroCamiseta { get; set; }
        public int Edad { get; set; }
        public double Sueldo { get; set; }
        public double Estatura { get; set; }
    }

}