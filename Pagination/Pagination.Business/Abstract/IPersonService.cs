using Pagination.Dto.Concrete;
using Pagination.Entity.Concrete;

namespace Pagination.Business.Abstract
{
    public interface IPersonService : IAsyncBaseService<Person, PersonDto>
    {
    }
}
