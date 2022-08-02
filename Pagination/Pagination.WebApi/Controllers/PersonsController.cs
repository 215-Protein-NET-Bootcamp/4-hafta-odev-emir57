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

        /// <summary>
        /// Add 1000 rows
        /// </summary>
        /// <returns></returns>
        [NonAction]
        [HttpGet]
        public async Task<IActionResult> TestAdd()
        {
            for (int i = 0; i < 1000; i++)
            {
                await base.AddAsync(new PersonDto
                {
                    FirstName = $"Emir{i}",
                    LastName = $"Gürbüz{i}",
                    Email = $"emir{i}@hotmail.com",
                    Description = "lorem",
                    Phone = "000",
                    DateOfBirth = new DateTime(2002, 9, 8)
                });
            }
            return Ok();
        }



    }
}
