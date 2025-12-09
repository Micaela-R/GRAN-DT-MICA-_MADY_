namespace GranDT.Core.Repos;

public interface IRepoPlantilla
{
    int AltaPlantilla(Plantilla plantillas);
    IEnumerable<Plantilla> TraerPlantillasPorIdUsuario(int idUsuario); 
    IEnumerable<Plantilla> TraerPlantillasPorIdUsuarioJ(int idPlantilla); 

    void AltaJugadorEnPlantilla(int idFutbolista, int idPlantilla, bool esTitular);

    IEnumerable<Plantilla> TraerPlantillasPorEmail(string email); 
    
}