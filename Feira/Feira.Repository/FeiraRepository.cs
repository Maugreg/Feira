using Dapper.Contrib.Extensions;
using Feira.Domain.Enums;
using Feira.Domain.Interfaces;
using Feira.Domain.Interfaces.Repository;
using Feira.Repository.Queries;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Feira.Repository
{
    public class FeiraRepository : BaseRepository, IFeiraRepository
    {
        private readonly IWrapperDbConnection _wrapperDbConnection;


        public FeiraRepository(IConfiguration config,
            IWrapperDbConnection wrapperDbConnection) : base(config)
        {
            _wrapperDbConnection = wrapperDbConnection;
        }

        public async Task<bool> InserirAsync(Feira.Domain.Entities.Feira feira)
        {
            using (var connection = _wrapperDbConnection.GetNewInstance(DbConnectionInfoType.Mysql, _connectionStringMySql))
            {
                var result = await connection.InsertAsync(feira).ConfigureAwait(false);

                return result > 0;
            }
        }


        public async Task<bool> ExcluirAsync(Feira.Domain.Entities.Feira feira)
        {
            using (var connection = _wrapperDbConnection.GetNewInstance(DbConnectionInfoType.Mysql, _connectionStringMySql))
            {
                var result = await connection.DeleteAsync(feira).ConfigureAwait(false);

                return result;
            }
        }


        public async Task<Feira.Domain.Entities.Feira> BuscarPorIdAsync(int id)
        {
            using (var connection = _wrapperDbConnection.GetNewInstance(DbConnectionInfoType.Mysql, _connectionStringMySql))
            {
                return await _wrapperDbConnection.QueryFirstOrDefaultAsync<Feira.Domain.Entities.Feira>(connection, FeiraQueries.BuscarPorID, new { id }).ConfigureAwait(false);
            }
        }

        public async Task<List<Feira.Domain.Entities.Feira>> BuscarFiltroAsync(string distrito, string regiao5, string nomeFeira, string bairro)
        {
            var sql = FeiraQueries.BuscarTodos;

            sql += RetornaQueryFiltros(distrito, regiao5, nomeFeira, bairro);

            using (var connection = _wrapperDbConnection.GetNewInstance(DbConnectionInfoType.Mysql, _connectionStringMySql))
            {
                var feiralist = await _wrapperDbConnection.QueryAsync<Feira.Domain.Entities.Feira>(connection, sql).ConfigureAwait(false);

                return feiralist.ToList();
            }
        }

        public async Task<bool> AlterarAsync(Feira.Domain.Entities.Feira feira)
        {
            using (var connection = _wrapperDbConnection.GetNewInstance(DbConnectionInfoType.Mysql, _connectionStringMySql))
            {
                return await connection.UpdateAsync(feira).ConfigureAwait(false);
            }
        }


        private string RetornaQueryFiltros(string distrito, string regiao5, string nomeFeira, string bairro)
        {
            StringBuilder query = new StringBuilder();

            if (!string.IsNullOrEmpty(distrito))
                query.Append($" AND DISTRITO = '{distrito}'");

            if (!string.IsNullOrEmpty(regiao5))
                query.Append($" AND Regiao5 = '{regiao5}'");

            if (!string.IsNullOrEmpty(nomeFeira))
                query.Append($" AND NOME_FEIRA = '{nomeFeira}'");

            if (!string.IsNullOrEmpty(bairro))
                query.Append($" AND BAIRRO = '{bairro}'");

            return query.ToString();

        }
    }
}
