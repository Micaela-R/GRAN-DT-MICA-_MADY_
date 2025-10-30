namespace GranDT.Core.Futbol;
    public class Puntuacion
    {
        // Identificador único de la puntuación
        public int IdPuntuacion { get; set; }

        // Relación futbolista
        public int IdFutbolista { get; set; }

        // Valor de puntaje 
        public float Puntaje { get; set; }

        // Fecha del partido  corresponde la puntuación
        public DateTime Fecha { get; set; }

        // Auditoría
        public string CargadoPor { get; set; } = string.Empty;
        public DateTime FechaCarga { get; set; } = DateTime.UtcNow;
        public string? ModificadoPor { get; set; }
        public DateTime? FechaModificacion { get; set; }

        // Propiedad de navegación 
        public virtual Futbolista? Futbolista { get; set; }

        // Constructor vacío (necesario para EF y serialización)
        public Puntuacion() { }

        // Constructor auxiliar
        public Puntuacion(int idFutbolista, float puntaje, DateTime fecha, string cargadoPor)
        {
            IdFutbolista = idFutbolista;
            Puntaje = puntaje;
            Fecha = fecha;
            CargadoPor = cargadoPor;
            FechaCarga = DateTime.UtcNow;
        }

        // Método para actualizar una puntuación existente
        public void ActualizarPuntaje(float nuevoPuntaje, string modificadoPor)
        {
            Puntaje = nuevoPuntaje;
            ModificadoPor = modificadoPor;
            FechaModificacion = DateTime.UtcNow;
        }
    }

