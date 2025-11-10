using System.Data;
using Dapper;
using GranDT.Core;
using GranDT.Core.Futbol;
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

    private static readonly string _queryPlantillasSinDetalle =
    @"SELECT  *
      FROM    Plantillas
      WHERE   idUsuario = @idUsuario;

      SELECT  u.idUsuario, u.Nombre, u.Apellido, u.Email
      FROM    Usuario u
      WHERE   u.idUsuario = @idUsuario;";

    public IEnumerable<Plantilla> ObtenerPlantillasSinDetalle(int idUsuario)
    {
    using (var multi = Conexion.QueryMultiple(_queryPlantillasSinDetalle, new { idUsuario }))
    {
            var plantillas = multi.Read<DtoPlantillaSinDetalle>().ToList();
    
            var usuario = multi.ReadSingle<Usuario>();

            return plantillas.Select(p => p.Plantilla(Usuario)).ToList();
    }
    }

    record struct DtoPlantillaSinDetalle(int idPlantilla, string nombre, int idUsuario)
    {
        public Plantilla Plantilla()
                    => new(idUsuario, nombre, idPlantilla);
    }

    //TODO plantilla super cargada en base al idplantilla
    
    private static readonly string _queryPlantillaSuperCargada

        = @" SELECT  
        idPlantilla, Nombre, idUsuario
        FROM    Plantillas
        WHERE   idPlantilla = @id;

        SELECT  idUsuario, Nombre, Apellido, Email, Nacimiento
        FROM    Usuario
        WHERE   idUsuario = (SELECT idUsuario FROM Plantillas WHERE idPlantilla = @id);

        SELECT  f.idFutbolista, f.Nombre, f.Apodo, f.Nacimiento, f.Cotizacion, f.Creado_por,
                e.idEquipo, e.Nombre AS NombreEquipo, e.Cantidad,
                tj.idTipoDeJugador, tj.Tipo
        FROM    Titular t
        JOIN    Futbolistas f ON t.idFutbolista = f.idFutbolista
        JOIN    Equipo e ON f.idEquipo = e.idEquipo
        JOIN    TipoDeJugador tj ON f.idTipoDeJugador = tj.idTipoDeJugador
        WHERE   t.idPlantilla = @id;

        SELECT  f.idFutbolista, f.Nombre, f.Apodo, f.Nacimiento, f.Cotizacion, f.Creado_por,
                e.idEquipo, e.Nombre AS NombreEquipo, e.Cantidad,
                tj.idTipoDeJugador, tj.Tipo
        FROM    Suplente s
        JOIN    Futbolistas f ON s.idFutbolista = f.idFutbolista
        JOIN    Equipo e ON f.idEquipo = e.idEquipo
        JOIN    TipoDeJugador tj ON f.idTipoDeJugador = tj.idTipoDeJugador
        WHERE   s.idPlantilla = @id;";

    public Plantilla? ObtenerPlantillaSuperCargada(int idPlantilla)
    {
        using (var multi = Conexion.QueryMultiple(_queryPlantillaSuperCargada, new { id = idPlantilla }))
        {
             // 1 Leemos la plantilla
            var dtoPlantilla = multi.ReadSingleOrDefault<DtoPlantillaSuperCargada?>();
                if (dtoPlantilla is null)
                return null;

            // 2 Leemos los titulares
            var titulares = multi.Read<DtoDetalleFutbolista>()
                             .Select(f => f.Futbolista())
                             .ToList();

            // 3 Leemos los suplentes
            var suplentes = multi.Read<DtoDetalleFutbolista>()
                             .Select(f => f.Futbolista())
                             .ToList();

            // 4 Construimos la plantilla completa
            return dtoPlantilla.Value.Plantilla(titulares, suplentes);
        }
    }

    record struct DtoPlantillaSuperCargada(int idPlantilla, string nombre, int idUsuario)
    {
    public Plantilla Plantilla(IEnumerable<Futbolista> titulares,
                               IEnumerable<Futbolista> suplentes)
        => new(idUsuario, nombre, idPlantilla)
        {
            Titulares = titulares,
            Suplentes = suplentes
        };
    }
    
    record struct DtoDetalleFutbolista(int idFutbolista,
    string nombre,
    string? apodo,
    DateTime nacimiento,
    decimal cotizacion,
    string creado_por,
    int idEquipo,
    string nombreEquipo,
    byte cantidad,
    int idTipoDeJugador,
    string tipo)

    {
        public Futbolista Futbolista(Equipo equipo, TipoDeJugador tipo,
                                    IEnumerable<Puntuacion> puntuaciones)
            => new(nombre, apodo, nacimiento, equipo, tipo, puntuaciones,
                    cotizacion, creado_por, idFutbolista);
    }
}
