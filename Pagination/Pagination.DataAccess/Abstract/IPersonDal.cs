using Core.DataAccess;
using Pagination.Entity.Concrete;

namespace Pagination.DataAccess.Abstract
{
    public interface IPersonDal : IAsyncEntityRepository<Person>
    {
    }
}
