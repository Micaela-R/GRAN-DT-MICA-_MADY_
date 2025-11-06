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
                        FROM Usuario
                        WHERE email = @unEmail
                        AND Contrasena = SHA2(@unaPass, 256)";

        var usuario = Conexion.QueryFirstOrDefault<Usuario>(sql, new { unEmail = email, unaPass = pass });

        return usuario;
    }

    //TODO plantillas sin detalle en base al idUsuario

    private static readonly string _queryPlantillaSinDetalle
    = @"SELECT  
        p.idPlantilla, 
        p.Nombre, 
        p.idUsuario,
        u.Nombre AS NombreUsuario, 
        u.Apellido AS ApellidoUsuario, 
        u.Email
        
        FROM    Plantillas p
        JOIN    Usuario u ON p.idUsuario = u.idUsuario
        WHERE   p.idUsuario = @idUsuario;";

    public IEnumerable<Plantilla> ObtenerPlantillasPorUsuario(int idUsuario)
    {
        using (var multi = Conexion.QueryMultiple(_queryPlantillaSinDetalle, new { idUsuario }))
        {
            var puntuaciones = multi.Read<Puntuacion>();
            var tipoDeJugador = multi.ReadSingle<TipoDeJugador>();
            var equipo = multi.ReadSingle<Equipo>();
        }
    }
    
    record struct DtoPlantillaSinDetalle(int idPlantilla, string nombre,
                                        int idUsuario, string nombreUsuario,
                                        string apellidoUsuario, string email)
    {
            public Plantilla Plantilla()
             => new (idPlantilla, nombre, new Usuario
            {
                IdUsuario = idUsuario,
                Nombre = nombreUsuario,
                Apellido = apellidoUsuario,
                Email = email
            });
}

    //TODO plantilla super cargada en base al idplantilla

}
