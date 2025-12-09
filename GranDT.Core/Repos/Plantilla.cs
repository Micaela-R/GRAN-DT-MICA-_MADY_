using GranDT.Core; 

namespace GranDT.Core
{
    public class Plantilla
    {
        public int IdPlantilla { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public int IdUsuario { get; set; }

        public virtual ICollection<FutbolistaPlantilla> FutbolistasPlantillas { get; set; } = new List<FutbolistaPlantilla>();

        public void AgregarFutbolista(int idFutbolista)
        {
            FutbolistasPlantillas.Add(new FutbolistaPlantillas)
            {
                IdFutbolista = idFutbolista,
                IdPlantilla = IdPlantilla
            };
        }
    }
}
