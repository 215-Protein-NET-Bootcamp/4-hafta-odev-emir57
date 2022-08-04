using Autofac;
using AutoMapper;
using Core.CrossCuttingConcerns.Caching;
using Core.Entity.Concrete;
using Core.Utilities.IoC;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using Pagination.Business.Concrete;
using Pagination.Business.DependencyResolvers.Autofac;
using Pagination.Business.Helpers;
using Pagination.DataAccess.Abstract;
using Pagination.Dto.Concrete;
using Pagination.Entity.Concrete;

namespace Pagination.Business.Test
{
    public class PersonManagerTest
    {
        Mock<IPersonDal> _personDalMock;
        Mock<ICacheManager> _cacheManager;
        IMapper _mapper;
        public PersonManagerTest()
        {
            _personDalMock = new Mock<IPersonDal>();
            _cacheManager = new Mock<ICacheManager>();
            var m = new MapperConfiguration(configure =>
            {
                configure.AddProfile(new BusinessAutoMapperHelper());
            });
            _mapper = m.CreateMapper();
        }
        [Theory]
        [InlineData(10, 1)]
        public async Task Pagination_return_10_rows(int pageSize, int pageNumber)
        {
            _personDalMock.Setup(x => x.GetListAsync(pageSize, (pageNumber == 1 ? 0 : pageNumber) * pageSize)).ReturnsAsync(getPersons());
            _cacheManager.Setup(x => x.IsAdd("patika")).Returns(false);

            PersonManager personManager = new PersonManager(_personDalMock.Object, _mapper, _cacheManager.Object);
            PaginationFilter paginationFilter = new PaginationFilter
            {
                CacheKey = "patika",
                PageNumber = pageNumber,
                PageSize = pageSize
            };

            var personsResult = await personManager.GetPaginationAsync(paginationFilter);

            Assert.Equal(personsResult.Data.Count(), 10);
        }

        private IEnumerable<Person> getPersons()
        {
            var random = new Random();
            for (int i = 0; i < 1000; i++)
            {
                yield return new Person
                {
                    Id = i + 1,
                    FirstName = $"Emir{i}",
                    LastName = $"Gürbüz{i}",
                    Email = $"emir{i}@hotmail.com",
                    Description = "lorem",
                    Phone = "000",
                    DateOfBirth = new DateTime(random.Next(1980, DateTime.Now.Year), random.Next(1, 12), random.Next(1, 30))
                };
            }
        }
    }
}
