using Core.Utilities.Helpers;
using Npgsql;
using System.Data;

namespace Pagination.DataAccess.Contexts
{
    public class DpPaginationDbContext
    {
        public IDbConnection CreateConnection()
        {
            return new NpgsqlConnection(ConnectionStringHelper.GetConnectionString("PostgreSqlConnection"));
        }
    }
}
