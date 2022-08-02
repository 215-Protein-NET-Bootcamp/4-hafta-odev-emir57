using Core.DataAccess.Dapper;
using Pagination.DataAccess.Abstract;
using Pagination.DataAccess.Contexts;
using Pagination.Entity.Concrete;

namespace Pagination.DataAccess.Concrete.Dapper
{
    public class DpPersonDal : DpBaseRepository<Person, DpPaginationDbContext>, IPersonDal
    {
    }
}
