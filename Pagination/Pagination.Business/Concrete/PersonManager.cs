using AutoMapper;
using Core.DataAccess;
using Core.Utilities.Results;
using Pagination.Business.Abstract;
using Pagination.Dto.Concrete;
using Pagination.Entity.Concrete;

namespace Pagination.Business.Concrete
{
    public class PersonManager : AsyncBaseManager<Person, PersonDto>, IPersonService
    {
        public PersonManager(IAsyncEntityRepository<Person> repository, IMapper mapper) : base(repository, mapper)
        {
        }
    }
}
