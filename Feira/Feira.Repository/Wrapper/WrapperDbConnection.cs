using Dapper;
using Dapper.Contrib.Extensions;
using Feira.Domain.Enums;
using Feira.Domain.Interfaces;
using MySql.Data.MySqlClient;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;

namespace Feira.Repository.Wrapper
{
    [ExcludeFromCodeCoverage]
    public class WrapperDbConnection : IWrapperDbConnection
    {
        public IDbConnection GetNewInstance(DbConnectionInfoType type, string connectionString)
        {
            switch (type)
            {
                case DbConnectionInfoType.Oracle:
                    return new OracleConnection(connectionString);
                case DbConnectionInfoType.SqlServer:
                    return new SqlConnection(connectionString);
                case DbConnectionInfoType.Mysql:
                    return new MySqlConnection(connectionString);
                default:
                    throw new NotImplementedException("Informação não implementada.");
            }
        }

        public IEnumerable<T> Query<T>(IDbConnection connection, string sql, object param = null)
        {
            return connection.Query<T>(sql, param);
        }

        public T QueryFirstOrDefault<T>(IDbConnection connection, string sql, object param = null)
        {
            return connection.QueryFirstOrDefault<T>(sql, param);
        }

        public int Execute(IDbConnection connection, string sql, object param = null, int? commandTimeout = null)
        {
            return connection.Execute(sql, param, commandTimeout: commandTimeout);
        }

        public T ExecuteScalar<T>(IDbConnection connection, string sql, object param = null)
        {
            return connection.ExecuteScalar<T>(sql, param);
        }

        public object ExecuteScalar(IDbConnection connection, string sql, object param = null)
        {
            return connection.ExecuteScalar(sql, param);
        }

        public async Task<IEnumerable<T>> QueryAsync<T>(IDbConnection connection, string sql, object param = null)
        {
            return await connection.QueryAsync<T>(sql, param).ConfigureAwait(false);
        }

        public async Task<int> ExecuteAsync(IDbConnection connection, string sql, object param = null)
        {
            return await connection.ExecuteAsync(sql, param).ConfigureAwait(false);
        }

        public async Task<T> QueryFirstOrDefaultAsync<T>(IDbConnection connection, string sql, object param = null)
        {
            return await connection.QueryFirstOrDefaultAsync<T>(sql, param).ConfigureAwait(false);
        }

    }
}
