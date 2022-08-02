using AutoMapper;
using Core.Entity.Concrete;
using Core.Utilities.Results;
using Pagination.Business.Abstract;
using Pagination.Business.Helpers;
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

        public async Task<PaginatedResult<IEnumerable<PersonDto>>> GetPaginationAsync(PaginationFilter paginationFilter)
        {
            IEnumerable<Person> persons = await Repository.GetListAsync();
            return PaginationHelper.CreatePaginatedResponse(Mapper.Map<IEnumerable<PersonDto>>(persons), paginationFilter, persons.Count());
        }
    }
}
