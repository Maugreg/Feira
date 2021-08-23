using Feira.Domain.Interfaces;

namespace Feira.Repository
{
    public class BaseRepository
    {
        protected readonly string _connectionStringOracle;
        protected readonly string _connectionStringSqlServer;
        protected readonly string _connectionStringMySql;

        public BaseRepository(IConfiguration configuration)
        {
            _connectionStringOracle = configuration?.Database?.Oracle?.ConnectionString ?? string.Empty;
            _connectionStringSqlServer = configuration?.Database?.SqlServer?.ConnectionString ?? string.Empty;
            _connectionStringMySql = configuration?.Database?.Mysql?.ConnectionString ?? string.Empty;
        }

    }
}
