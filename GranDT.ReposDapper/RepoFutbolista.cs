using System.Data;
using GranDT.Core.Futbol;
using Dapper;
using GranDT.Core.Repos;

namespace GranDT.ReposDapper;
public class RepoFutbolista : Repo, IRepoFutbolista
{
    public RepoFutbolista(IDbConnection conexion) : base(conexion)
    {
    }

    public void AltaFutbolista(Futbolista futbolista)
    {
        var parametros = new DynamicParameters();

        parametros.Add("@p_Nombre", futbolista.Nombre);
        parametros.Add("@p_Apodo", futbolista.Apodo);
        parametros.Add("@p_Nacimiento", futbolista.Nacimiento);
        parametros.Add("@p_idFutbolista", futbolista.IdFutbolista);
        parametros.Add("@p_idEquipo", futbolista.Equipo.idEquipo);
        parametros.Add("@p_idTipoDeJugador", futbolista.TipoDeJugador.IdTipoDeJugador);
        parametros.Add("@p_Cotizacion", futbolista.Cotizacion);
        parametros.Add("@p_Creado_por", futbolista.Creado_por);

        try
        {
            Conexion.Execute("alta_futbolista", parametros, commandType: CommandType.StoredProcedure);
        }
        catch (Exception)
        {
            throw;
        }
    }

    // Obtener todos los futbolistas
    public IEnumerable<Futbolista> ObtenerFutbolistas()
    {
        var sql = "SELECT idFutbolista, Nombre, Apodo, Nacimiento, idEquipo, idTipoDeJugador, Cotizacion, Creado_por FROM Futbolistas";
        return Conexion.Query<Futbolista>(sql);
    }

    // Obtener todos los tipos de jugadores
    public IEnumerable<TipoDeJugador> ObtenerTipoJugadores()
    {
        var sql = "SELECT idTipoDeJugador, Tipo FROM TipoDeJugador";
        return Conexion.Query<TipoDeJugador>(sql);
    }

    // Obtener a los futbolistas en base a su IdTipo

    public IEnumerable<Futbolista> ObtenerFutbolistasPorTipo(int idTipoDeJugador)
    {
    var sql = @"
        SELECT  f.idFutbolista, f.Nombre, f.Apodo, f.Nacimiento, 
                f.Cotizacion, f.Creado_por
        FROM    Futbolistas f
        WHERE   f.idTipoDeJugador = @idTipo;

        SELECT  e.idEquipo, e.Nombre
        FROM    Equipo e
        JOIN    Futbolistas f ON f.idEquipo = e.idEquipo
        WHERE   f.idTipoDeJugador = @idTipo;

        SELECT  tj.idTipoDeJugador, tj.Tipo
        FROM    TipoDeJugador tj
        WHERE   tj.idTipoDeJugador = @idTipo;

        SELECT  p.*
        FROM    Puntuacion p
        JOIN    Futbolistas f ON p.idFutbolista = f.idFutbolista
        WHERE   f.idTipoDeJugador = @idTipo;";

        using (var multi = Conexion.QueryMultiple(sql, new { idTipo = idTipoDeJugador }))
        {
            var futbolistasDto = multi.Read<DtoDetalleFutbolista>().ToList();

            if (!futbolistasDto.Any())
                return Enumerable.Empty<Futbolista>();

                var equipos = multi.Read<Equipo>().ToList();

                var tipo = multi.ReadSingle<TipoDeJugador>();

                var puntuaciones = multi.Read<Puntuacion>().ToList();

            return futbolistasDto.Select(dto =>
            {
                var equipo = equipos.First(e => 
                true // ya que la consulta trae solo los del mismo tipo
                );

                var puntajeFutbоlista = puntuaciones
                .Where(p => p.idFutbolista == dto.IdFutbolista);

                return dto.Futbolista(equipo, tipo, puntuaciones);
            });
        }
    }

    // Obtener a los futbolistas con sus puntuaciones cargadas

    private static readonly string _queryFutbolista

        = @"SELECT *
            FROM    Futbolistas
            WHERE   idFutbolista = @id;

        SELECT  e.idEquipo, e.nombre
        FROM    Futbolistas f
        JOIN    Equipo e ON f.idEquipo = e.idEquipo
        WHERE   f.idFutbolista = @id;

        SELECT  tj.idTipoDeJugador, tj.tipo
        FROM    Futbolistas f
        JOIN    TipoDeJugador tj ON f.idTipoDeJugador = tj.idTipoDeJugador
        WHERE   f.idFutbolista = @id;

        SELECT  *
        FROM    Puntuacion
        WHERE   idFutbolista = @id;";

    public Futbolista? ObtenerFutbolista(int idFutbolista)
    {
        using (var multi = Conexion.QueryMultiple(_queryFutbolista, new { id = idFutbolista }))
        {
            var futbolista = multi.ReadSingleOrDefault<DtoDetalleFutbolista>();
            if (futbolista is not null)
            {
                var equipo = multi.ReadSingle<Equipo>();
                var tipoDeJugador = multi.ReadSingle<TipoDeJugador>();
                var puntuaciones = multi.Read<Puntuacion>();

                return futbolista.Futbolista(equipo, tipoDeJugador, puntuaciones);
            }
        }
        return null;
    }

    internal class DtoDetalleFutbolista
    {
        private readonly int idFutbolista;
        private readonly string nombre;
        private readonly string? apodo;
        private readonly DateTime nacimiento;
        private readonly decimal cotizacion;
        private readonly string creado_por;

        public DtoDetalleFutbolista(int idFutbolista, int idEquipo, int idTipoDeJugador, string nombre, string? apodo,
                                            DateTime nacimiento, decimal cotizacion, string creado_por)
        {
            this.idFutbolista = idFutbolista;
            this.nombre = nombre;
            this.apodo = apodo;
            this.nacimiento = nacimiento;
            this.cotizacion = cotizacion;
            this.creado_por = creado_por;
        }

        public int IdFutbolista => idFutbolista;

        public Futbolista Futbolista(Equipo equipo, TipoDeJugador tipo,
                                    IEnumerable<Puntuacion> puntuaciones)
            => new(nombre, apodo, nacimiento, equipo, tipo, puntuaciones,
                    cotizacion, creado_por, idFutbolista);
    }

}
