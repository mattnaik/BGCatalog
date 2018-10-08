using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using static Dapper.SqlMapper;

namespace BGCatalog.DataAccess.Interfaces
{
    public interface IDapperQueryWrapper
    {
        int Execute(IDbConnection conn, string sql, object param, CommandType commandType);
        T ExecuteScalar<T>(IDbConnection conn, string sql, object param, CommandType commandType);
        IEnumerable<T> Query<T>(IDbConnection conn, string sql, object param, CommandType commandType);
        GridReader QueryMulitple(IDbConnection conn, string sql, object param, CommandType commandType);
    }
}
