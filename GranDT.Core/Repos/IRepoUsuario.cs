namespace GranDT.Core.Repos;

public interface IRepoUsuario
{
    void AltaUsuario(Usuario usuario, string pass);
    Usuario? UsuarioPorPass(string email, string pass);
}