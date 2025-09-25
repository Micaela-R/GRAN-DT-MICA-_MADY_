using System.Data;
using GranDT.Core;
using GranDT.Core.Repos;

namespace GranDT.ReposDapper;

public class RepoUsuario : Repo, IRepoUsuario
{
    public RepoUsuario(IDbConnection conexion) : base(conexion)
    {
    }

    public void AltaUsuario(Usuario usuario)
    {
        throw new NotImplementedException();
    }

    public Usuario? UsuarioPorPass(string email, string pass)
    {
        throw new NotImplementedException();
    }
}
