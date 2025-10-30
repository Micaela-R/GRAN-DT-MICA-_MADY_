namespace GranDT.Core.Futbol;

public class Equipo
{

    public int idEquipo { get; set; }
    public byte Cantidad { get; set; }
    public string Nombre { get; set; } = string.Empty;


    private List<string>jugadores;

    public IReadOnlyList<string> Jugadores => jugadores.AsReadOnly();
    
        public Equipo()
        {
            jugadores = new List<string>();
        }

        // Constructor con parámetros
        public Equipo(int IdEquipo, string nombre, byte cantidad)
        {
            IdEquipo = idEquipo;
            Nombre = nombre;
            Cantidad = cantidad;
            jugadores = new List<string>();
        }

        // Método para agregar un jugador al equipo
        public bool AgregarJugador(string jugador)
        {
            if (jugadores.Count >= Cantidad)
            {
                Console.WriteLine($"No se puede agregar más jugadores, el equipo {Nombre} ya tiene el máximo de {Cantidad} jugadores.");
                return false;
            }

            jugadores.Add(jugador);
            Console.WriteLine($"Jugador {jugador} agregado al equipo {Nombre}.");
            return true;
        }

        // Método para eliminar un jugador del equipo
        public bool EliminarJugador(string jugador)
        {
            if (jugadores.Contains(jugador))
            {
                jugadores.Remove(jugador);
                Console.WriteLine($"Jugador {jugador} eliminado del equipo {Nombre}.");
                return true;
            }
            else
            {
                Console.WriteLine($"El jugador {jugador} no se encuentra en el equipo {Nombre}.");
                return false;
            }
        }

        //  información del equipo
        public void MostrarInformacion()
        {
            Console.WriteLine($"Equipo: {Nombre} (ID: {idEquipo})");
            Console.WriteLine($"Cantidad máxima de jugadores: {Cantidad}");
            Console.WriteLine($"Jugadores actuales: {jugadores.Count}");

            if (jugadores.Count > 0)
            {
                Console.WriteLine("Jugadores:");
                foreach (var jugador in jugadores)
                {
                    Console.WriteLine($"- {jugador}");
                }
            }
            else
            {
                Console.WriteLine("No hay jugadores en el equipo.");
            }
        }
    }
