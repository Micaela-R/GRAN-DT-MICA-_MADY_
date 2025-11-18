namespace GranDT.Core.Repos;

public interface IRepoUsuario
{
    void AltaUsuario(Usuario usuario, string pass);
    Plantilla? ObtenerPlantillasSinDetalle(int idUsuario);
    Plantilla? ObtenerPlantillaSuperCargada(int idPlantilla);
    Usuario? UsuarioPorPass(string email, string pass);
}