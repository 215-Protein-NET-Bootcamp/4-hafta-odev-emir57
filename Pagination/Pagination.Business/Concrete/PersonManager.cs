using AutoMapper;
using Pagination.Business.Abstract;
using Pagination.DataAccess.Abstract;
using Pagination.Dto.Concrete;
using Pagination.Entity.Concrete;

namespace Pagination.Business.Concrete
{
    public class PersonManager : AsyncBaseManager<Person, PersonDto>, IPersonService
    {
        public PersonManager(IPersonDal repository, IMapper mapper) : base(repository, mapper)
        {
        }
    }
}
