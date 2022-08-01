using AutoMapper;
using Core.DataAccess;
using Core.Dto;
using Core.Entity;
using Core.Utilities.Results;
using Pagination.Business.Abstract;

namespace Pagination.Business.Concrete
{
    public class AsyncBaseManager<TEntity, TDto> : IAsyncBaseService<TEntity, TDto>
        where TEntity : class, IEntity, new()
        where TDto : class, IDto, new()
    {
        protected readonly IAsyncEntityRepository<TEntity> Repository;
        protected readonly IMapper Mapper;
        public AsyncBaseManager(IAsyncEntityRepository<TEntity> repository, IMapper mapper)
        {
            Repository = repository;
            Mapper = mapper;
        }
        public async Task<IDataResult<TDto>> AddAsync(TDto dto)
        {
            TEntity addedEntity = Mapper.Map<TEntity>(dto);
            await Repository.AddAsync(addedEntity);
            return new SuccessDataResult<TDto>(dto);
        }

        public async Task<IResult> DeleteAsync(int id)
        {
            TEntity deletedEntity = await Repository.GetAsync(t => t.Id == id);
            await Repository.DeleteAsync(deletedEntity);
            return new SuccessResult();
        }

        public async Task<IDataResult<TDto>> GetByIdAsnc(int id)
        {
            TEntity entity = await Repository.GetAsync(t => t.Id == id);
            TDto returnEntity = Mapper.Map<TDto>(entity);
            return new SuccessDataResult<TDto>(returnEntity);
        }

        public async Task<IDataResult<List<TDto>>> GetListAsync()
        {
            IEnumerable<TEntity> entities = await Repository.GetListAsync();
            IEnumerable<TDto> result = Mapper.Map<IEnumerable<TDto>>(entities);
            return new SuccessDataResult<List<TDto>>(result.ToList());
        }

        public async Task<IDataResult<TDto>> UpdateAsync(int id, TDto dto)
        {
            TEntity updatedEntity = await Repository.GetAsync(t => t.Id == id);
            Mapper.Map(updatedEntity, dto);
            await Repository.UpdateAsync(updatedEntity);
            return new SuccessDataResult<TDto>(dto);
        }
    }
}
