using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace BGCatalogDataAccess.Interfaces
{
    public interface IDbConnectionFactory
    {
        IDbConnection GetConnection(string ConnectionString);
        IDbConnection GetConnection();

    }
}
