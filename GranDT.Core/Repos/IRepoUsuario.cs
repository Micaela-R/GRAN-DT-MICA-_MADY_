namespace GranDT.Core.Repos;

public interface IRepoUsuario
{
    void AltaUsuario(Usuario usuario);
    Usuario? UsuarioPorPass(string email, string pass);
}