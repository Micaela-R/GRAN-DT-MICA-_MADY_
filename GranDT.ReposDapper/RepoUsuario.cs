using System.Data;
using Dapper;
using GranDT.Core;
using GranDT.Core.Repos;

namespace GranDT.ReposDapper;

public class RepoUsuario : Repo, IRepoUsuario
{
    public RepoUsuario(IDbConnection conexion) : base(conexion)
    {
    }

    public void AltaUsuario(Usuario usuario, string pass)
    {
        var parametros = new DynamicParameters();

        parametros.Add("@unIdUsuario", direction: ParameterDirection.Output);
        parametros.Add("@unEmail", usuario.Email);
        parametros.Add("@unNombre", usuario.Nombre);
        parametros.Add("@unApellido", usuario.Apellido);
        parametros.Add("@unNacimiento", usuario.Nacimiento);

        try
        {
            Conexion.Execute("AltaUsuario", parametros);
            usuario.IdUsuario = parametros.Get<int>("unIdUsuario");
        }
        catch (System.Exception)
        {
            throw;
        }
    }

    public Usuario? UsuarioPorPass(string email, string pass)
    {
        var sql = @"
                        SELECT  idUsuario, Email, Nombre, Apellido, Nacimiento
                        FROM Usuarios
                        WHERE email = @unEmail
                        AND pass = SHA2(@unaPass, 256)";

        var usuario = Conexion.QueryFirstOrDefault<Usuario>(sql, new { Email = email, Pass = pass });

        return usuario;
    }
}
