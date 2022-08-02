﻿using AutoMapper;
using Core.CrossCuttingConcerns.Caching;
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
        private readonly ICacheManager _cacheManager;
        public PersonManager(IPersonDal repository, IMapper mapper, ICacheManager cacheManager) : base(repository, mapper)
        {
            _cacheManager = cacheManager;
        }

        public async Task<PaginatedResult<IEnumerable<PersonDto>>> GetPaginationAsync(PaginationFilter paginationFilter)
        {
            string cacheKey = $"{paginationFilter.CacheKey}+{paginationFilter.PageSize}+{paginationFilter.PageNumber}";
            if (_cacheManager.IsAdd(cacheKey))
            {
                IEnumerable<PersonDto> cachePersons = _cacheManager.Get<IEnumerable<PersonDto>>(cacheKey);
                return PaginationHelper.CreatePaginatedResponse(Mapper.Map<IEnumerable<PersonDto>>(cachePersons), paginationFilter, cachePersons.Count(), skip: false);
            }
            IEnumerable<Person> persons = await Repository.GetListAsync();
            var result = PaginationHelper.CreatePaginatedResponse(Mapper.Map<IEnumerable<PersonDto>>(persons), paginationFilter, persons.Count());
            _cacheManager.Add(cacheKey, result.Data, 10);
            return result;
        }
    }
}
