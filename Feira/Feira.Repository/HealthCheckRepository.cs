using Feira.Domain.Entities;
using Feira.Domain.Enums;
using Feira.Domain.Interfaces;
using Feira.Domain.Interfaces.Repository;
using Feira.Repository.Queries;
using System.Linq;
using System.Threading.Tasks;

namespace Feira.Repository
{
    public class HealthCheckRepository : BaseRepository, IHealthCheckRepository
    {
        private readonly IWrapperDbConnection _wrapperDbConnection;


        public HealthCheckRepository(IConfiguration config,
            IWrapperDbConnection wrapperDbConnection) : base(config)
        {
            _wrapperDbConnection = wrapperDbConnection;
        }

     

        public async Task<bool> CheckDataBaseMySqlStatusAsync()
        {

            using (var connection = _wrapperDbConnection.GetNewInstance(DbConnectionInfoType.Mysql, _connectionStringMySql))
            {
                var result = await _wrapperDbConnection.QueryAsync<HealthCheck>(connection,
                    HealthCheckQueries.SelectDataBaseMysqlStatus).ConfigureAwait(false);

                return result.Any();
            }
        }
    }
}
