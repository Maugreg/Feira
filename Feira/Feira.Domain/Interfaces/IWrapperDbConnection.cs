using Feira.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace Feira.Domain.Interfaces
{
    public interface IWrapperDbConnection
    {
        IDbConnection GetNewInstance(DbConnectionInfoType type, string connectionString);

        IEnumerable<T> Query<T>(IDbConnection connection, string sql, object param = null);
        T QueryFirstOrDefault<T>(IDbConnection connection, string sql, object param = null);
        int Execute(IDbConnection connection, string sql, object param = null, int? commandTimeout = null);
        Task<IEnumerable<T>> QueryAsync<T>(IDbConnection connection, string sql, object param = null);
        T ExecuteScalar<T>(IDbConnection connection, string sql, object param = null);
        object ExecuteScalar(IDbConnection connection, string sql, object param = null);
        Task<int> ExecuteAsync(IDbConnection connection, string sql, object param = null);
        Task<T> QueryFirstOrDefaultAsync<T>(IDbConnection connection, string sql, object param = null);    }
}
