Logica.SingletonLogica logica = Logica.SingletonLogica.Instance;
Persistencia.SingletonPersistencia.Instance.PasarEntidad += logica.PasarEntidadHandler;
logica.ImprimirEntidad += ImprimirEntidadHandler;
Console.WriteLine("A = dar alta jugador, B = dar baja jugador, M = modificar jugador y S = salir");
string accion = Console.ReadLine();
while (accion != "S")
{
    switch (accion)
    {
        case "A":
            Console.WriteLine("Ingrese Edad");
            int edad = int.Parse(Console.ReadLine());
            Console.WriteLine("Ingrese numero de camiseta");
            int numeroCamiseta = int.Parse(Console.ReadLine());
            Console.WriteLine("Ingrese el sueldo");
            double sueldo = double.Parse(Console.ReadLine());
            Console.WriteLine("Ingrese la estatura");
            double estatura = double.Parse(Console.ReadLine());
            logica.DarAltaJugador(edad, numeroCamiseta, sueldo, estatura);
            break;
        case "B":
            Console.WriteLine("Ingrese la identificacion del jugador que desea eliminar");
            int identificacion = int.Parse(Console.ReadLine());
            logica.DarBajaJugador(identificacion);
            break;
        case "M":
            Console.WriteLine("Ingrese la identificacion del jugador a modificiar");
            int identificacionJugadorModificar = int.Parse(Console.ReadLine());
            Console.WriteLine("Ingrese nuevo numero de camiseta (0 para no modificar)");
            int numeroCamisetaModificar = int.Parse(Console.ReadLine());
            Console.WriteLine("Ingrese nuevo sueldo (0 para no modificar)");
            double sueldoModificar = double.Parse(Console.ReadLine());
            logica.ModificarJugador(identificacionJugadorModificar);
            break;
        default:
            break;
    }
    Thread.Sleep(1000);
    Console.Clear();
    Console.WriteLine("A = dar alta jugador, B = dar baja jugador, M = modificar jugador y S = salir");
    accion = Console.ReadLine();
}
static void ImprimirEntidadHandler(object? sender, Entidades.ImprimirEntidadEventArgs entidad)
{
    int ban = 0;
    while (ban == 0)
    {
        Console.WriteLine(entidad.Identificacion);
        Console.WriteLine(entidad.Edad);
        Console.WriteLine(entidad.NumeroCamiseta);
        Console.WriteLine(entidad.Sueldo);
        Console.WriteLine(entidad.Estatura);
        ban = 1;
    }
}
Console.Read();

