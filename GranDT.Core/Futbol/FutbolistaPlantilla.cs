namespace GranDT.Core.Futbol;
    public class FutbolistaPlantilla
    {
        // Clave compuesta 
        public int IdFutbolista { get; set; }
        public int IdPlantilla { get; set; }

        // Constructor vacio
        public FutbolistaPlantilla() { }

        // constructor para iniciar rapido y facil
        public FutbolistaPlantilla(int idFutbolista, int idPlantilla)
        {
            IdFutbolista = idFutbolista;
            IdPlantilla = idPlantilla;
        }
    }

