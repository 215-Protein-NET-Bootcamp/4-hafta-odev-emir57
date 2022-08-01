using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pagination.DataAccess.Contexts
{
    public class DpPaginationDbContext
    {
        public IDbConnection CreateConnection()
        {
            return new NpgsqlConnection();
        }
    }
}
