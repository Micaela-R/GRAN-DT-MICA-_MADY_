namespace GranDT.Core.Repos;

public interface IRepoUsuario
{
    void AltaUsuario(Usuario usuario, string pass);
    Plantilla? ObtenerPlantillasSinDetalle(int idPlantilla);
    Plantilla? ObtenerPlantillaSuperCargada(int idPlantilla);
    Usuario? UsuarioPorPass(string email, string pass);
}