using Core.DataAccess.EntityFramework;
using Pagination.DataAccess.Abstract;
using Pagination.DataAccess.Contexts;
using Pagination.Entity.Concrete;

namespace Pagination.DataAccess.Concrete.EntityFramework
{
    public class EfPersonDal : EfBaseRepository<Person, EfPaginationDbContext>, IPersonDal
    {
        public Task<IEnumerable<Person>> GetListAsync(int? limit = 0, int? offset = 0)
        {
            throw new NotImplementedException();
        }
    }
}
