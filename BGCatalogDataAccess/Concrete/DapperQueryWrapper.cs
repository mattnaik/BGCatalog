using BGCatalog.DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using static Dapper.SqlMapper;

namespace BGCatalog.DataAccess.Concrete
{
    public class DapperQueryWrapper: IDapperQueryWrapper
    {
        public int Execute(IDbConnection conn, string sql, object param, CommandType commandType)
        {
            return conn.Execute(sql, param, commandType: commandType, commandTimeout: 200);
        }

        public T ExecuteScalar<T>(IDbConnection conn, string sql, object param, CommandType commandType)
        {
            return conn.ExecuteScalar<T>(sql, param, commandType: commandType, commandTimeout: 200);
        }

        public IEnumerable<T> Query<T>(IDbConnection conn, string sql, object param, CommandType commandType)
        {
            return conn.Query<T>(sql, param, commandType: commandType, commandTimeout: 200);
        }

        public GridReader QueryMulitple(IDbConnection conn, string sql, object param, CommandType commandType)
        {
            return conn.QueryMultiple(sql, param, commandType: commandType, commandTimeout: 200);
        }
    }
}
