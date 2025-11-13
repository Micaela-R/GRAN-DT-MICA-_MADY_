namespace GranDT.Core.Futbol
{
    public class Equipo
    {
        public int idEquipo { get; set; }
        public byte Cantidad { get; set; }
        public string Nombre { get; set; } = string.Empty;

        private List<string> jugadores;

        public IReadOnlyList<string> Jugadores => jugadores.AsReadOnly();

        public Equipo()
        {
            jugadores = new List<string>();
        }

        public Equipo(int idEquipo, string nombre, byte cantidad)
        {
            this.idEquipo = idEquipo;
            this.Nombre = nombre;
            this.Cantidad = cantidad;
            jugadores = new List<string>();
        }
    }
}


     