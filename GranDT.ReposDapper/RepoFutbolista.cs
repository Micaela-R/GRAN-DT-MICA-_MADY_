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
            parametros.Add("@p_idEquipo", futbolista.idEquipo);
            parametros.Add("@p_idTipoDeJugador", futbolista.idTipoDeJugador);
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
            var sql = "SELECT idFutbolistas, Nombre, Apodo, Nacimiento, idEquipo, idTipoDeJugador, Cotizacion, Creado_por FROM Futbolistas";
            return Conexion.Query<Futbolista>(sql);
        }

        // Obtener todos los tipos de jugadores
        public IEnumerable<TipoDeJugador> ObtenerTipoJugadores()
        {
            var sql = "SELECT idTipoDeJugador, Tipo FROM TipoDeJugador";
            return Conexion.Query<TipoDeJugador>(sql);
        }
}
