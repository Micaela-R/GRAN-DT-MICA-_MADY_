namespace GranDT.Core.Futbol;

    public class Futbolista
    {
        // se identifica al futbolista UNICO
        public int IdFutbolista { get; set; }

        // Datos personales
        public string Nombre { get; set; } = string.Empty;
        public string Apodo { get; set; } = string.Empty;
        public DateTime Nacimiento { get; set; }

        // Relaciones con otras entidades
        public int IdEquipo { get; set; }
        public int IdTipoDeJugador { get; set; }

        // Datos económicos
        public decimal Cotizacion { get; set; }

        // Auditoría
        public string CreadoPor { get; set; } = string.Empty;
        public DateTime FechaCreacion { get; set; } = DateTime.UtcNow;
        public string ModificadoPor { get; set; } = string.Empty;
        public DateTime FechaModificacion { get; set; }


        // Constructor opcional para crear fácilmente instancias
        public Futbolista (string nombre, string apodo, DateTime nacimiento, int idEquipo, int idTipoDeJugador, decimal cotizacion, string creadoPor)
        {
            Nombre = nombre;
            Apodo = apodo;
            Nacimiento = nacimiento;
            IdEquipo = idEquipo;
            IdTipoDeJugador = idTipoDeJugador;
            Cotizacion = cotizacion;
            CreadoPor = creadoPor;
            FechaCreacion = DateTime.UtcNow;
        }

        // calcular la edad actual del jugador
        public int CalcularEdad()
        {
            var hoy = DateTime.Today;
            var edad = hoy.Year - Nacimiento.Year;
            if (Nacimiento.Date > hoy.AddYears(-edad)) edad--;
            return edad;
        }

        // se actualiza cotización
        public void ActualizarCotizacion(decimal nuevaCotizacion, string modificadoPor)
        {
            Cotizacion = nuevaCotizacion;
            ModificadoPor = modificadoPor;
            FechaModificacion = DateTime.UtcNow;
        }
    }

