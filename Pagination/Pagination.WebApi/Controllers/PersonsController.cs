using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Pagination.Business.Abstract;
using Pagination.Dto.Concrete;
using Pagination.Entity.Concrete;

namespace Pagination.WebApi.Controllers
{
    [Route("api/[controller]")]
    public class PersonsController : BaseController<Person, PersonDto>
    {
        public PersonsController(IPersonService service, IMapper mapper) : base(service, mapper)
        {
        }
    }
}
