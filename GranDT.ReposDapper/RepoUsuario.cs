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

    private static readonly string _queryPlantillaSinDetalle
        = @"SELECT  *
        FROM    Plantillas
        WHERE   idUsuario = @idUsuario;";

    public IEnumerable<Plantilla> ObtenerPlantillasSinDetalle(int idUsuario)
    {
        return Conexion.Query<Plantilla>(_queryPlantillaSuperCargada);
    }

    private IEnumerable<Plantilla> Read<T>()
    {
        throw new NotImplementedException();
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
        
        SELECT  *
        FROM    PlantillaTitulares
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
            IEnumerable<Futbolista> titulares = multi.Read<DtoDetalleFutbolista>()
                            .Select(dtoFutbolista => dtoFutbolista.Futbolista());

            // 3 Leemos los suplentes
            var suplentes = multi.Read<DtoDetalleFutbolista>()
                            .Select(f => f.Futbolista())
                            .ToList();

            // 4 Construimos la plantilla completa
            return dtoPlantilla.Value.Plantilla(titulares, suplentes);
        }
    }

    Plantilla? IRepoUsuario.ObtenerPlantillasSinDetalle(int idUsuario)
    {
        var plantilla = Conexion.QueryFirstOrDefault<Plantilla>(_queryPlantillaSinDetalle, new{ id = idUsuario });
        return plantilla;;
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

    record struct DtoDetalleFutbolista(int IdFutbolista,
        string nombre,
        string? apodo,
        DateTime nacimiento,
        decimal cotizacion,
        string creado_por,
        int idEquipo,
        string nombreEquipo,
        int idTipoDeJugador,
        string tipo)
    {
        public Futbolista Futbolista()
        {
            var equipo =
                new Equipo()
                {
                    idEquipo = idEquipo,
                    Nombre = nombreEquipo
                };

            var tipoFutbolista =
                new TipoDeJugador()
                {
                    IdTipoDeJugador = idTipoDeJugador,
                    Tipo = tipo
                };

            return
                new Futbolista(nombre, apodo, nacimiento,
                    equipo, tipoFutbolista, [], cotizacion,
                    creado_por, IdFutbolista);
        }

    }
}
