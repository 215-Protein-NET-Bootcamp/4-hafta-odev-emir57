using Core.Dto;
using Core.Entity;
using System.Linq.Expressions;

namespace Core.DataAccess.Dapper
{
    public class DpBaseRepository<TEntity, TDto> : IAsyncEntityRepository<TEntity, TDto>
        where TEntity : class, IEntity, new()
        where TDto : class, IDto, new()
    {
        public Task<TEntity> AddAsync(TDto entity)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<TDto> GetAsync(Expression<Func<TDto, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<TDto>> GetListAsync()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<TDto>> GetListAsync(Expression<Func<TDto, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Task<TEntity> UpdateAsync(int id, TDto entity)
        {
            throw new NotImplementedException();
        }
    }
}
