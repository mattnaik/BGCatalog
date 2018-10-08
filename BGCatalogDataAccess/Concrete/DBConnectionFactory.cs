using System;
using System.Data;
using System.Data.SqlClient;
using BGCatalogDataAccess.Interfaces;
using Dapper;

namespace BGCatalogDataAccess.Concrete
{
    public class DbConnectionFactory : IDbConnectionFactory
    {
        public DbConnectionFactory() { }
        public IDbConnection GetConnection(string ConnectionString)
        {
            return new SqlConnection(ConnectionString);
        }

        public IDbConnection GetConnection()
        {
            //TODO: move to config
            string connString = @"Server=localhost\SQLEXPRESS;Database=master;Trusted_Connection=True;";
            return GetConnection(connString);
        }
    }
}
