using GranDT.Core; // asegúrate de tener esto

namespace GranDT.Core
{
    public class Plantilla
    {
        public int IdPlantilla { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public int IdUsuario { get; set; }

        public virtual ICollection<FutbolistaPlantilla> FutbolistasPlantilla { get; set; } = new List<FutbolistaPlantilla>();

        public void AgregarFutbolista(int idFutbolista)
        {
            FutbolistasPlantilla.Add(new FutbolistaPlantilla
            {
                IdFutbolista = idFutbolista,
                IdPlantilla = IdPlantilla
            });
        }
    }
}
