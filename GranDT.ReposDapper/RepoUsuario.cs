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

        parametros.Add("@idUsuario", direction: ParameterDirection.Output);
        parametros.Add("@p_Email", usuario.Email);
        parametros.Add("@p_Nombre", usuario.Nombre);
        parametros.Add("@p_Apellido", usuario.Apellido);
        parametros.Add("@p_Nacimiento", usuario.Nacimiento);
        parametros.Add("@p_Contrasena", pass);

        try
        {
            Conexion.Execute("alta_usuario", parametros);
            usuario.IdUsuario = parametros.Get<int>("idUsuario");
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
