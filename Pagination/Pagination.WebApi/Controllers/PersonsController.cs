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

        [HttpGet]
        public async Task<IActionResult> TestAdd()
        {
            return await base.AddAsync(new PersonDto
            {
                FirstName = "Emir",
                LastName = "Gürbüz",
                Email = "emir@hotmail.com",
                Description = "lorem",
                Phone = "000",
                DateOfBirth = new DateTime(2002, 9, 8)
            });
        }
    }
}
